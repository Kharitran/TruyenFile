using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Server.Core;
using Server;
using SharedLibrary.Enums;
using SharedLibrary.Models;
using SharedLibrary.Protocol;

namespace Server.Core
{
    public class ClientSession
    {
        private TcpClient client;
        private NetworkStream stream;
        private string storagePath;
        private Authentication auth;
        private ServerForm serverForm;
        private bool isAuthenticated = false;
        private const long MAX_FILE_SIZE = 2L * 1024 * 1024 * 1024; // 2GB - THÊM GIỚI HẠN

        public string Username { get; private set; }
        public string IPAddress { get; private set; }
        public UserRole Role { get; private set; }

        public ClientSession(TcpClient client, string storagePath, Authentication auth, ServerForm serverForm)
        {
            this.client = client;
            this.stream = client.GetStream();
            this.storagePath = storagePath;
            this.auth = auth;
            this.serverForm = serverForm;
            this.IPAddress = ((System.Net.IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

            this.client.ReceiveTimeout = 300000; 
            this.client.SendTimeout = 300000;

            this.client.SendBufferSize = 65536;
            this.client.ReceiveBufferSize = 65536;

            Directory.CreateDirectory(storagePath);
        }

        public void HandleClient()
        {
            try
            {
                while (client.Connected)
                {
                    try
                    {
                        if (!stream.DataAvailable)
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        string commandStr = FileTransferProtocol.ReceiveString(stream);

                        if (Enum.TryParse(commandStr, out CommandType command))
                        {
                            switch (command)
                            {
                                case CommandType.Login:
                                    HandleLogin();
                                    break;
                                case CommandType.Register:
                                    HandleRegister();
                                    break;
                                case CommandType.SendFile:
                                    if (isAuthenticated)
                                        HandleFileReceive();
                                    else
                                        FileTransferProtocol.SendString(stream, "ERROR:Not authenticated");
                                    break;
                                case CommandType.RequestFile:
                                    if (isAuthenticated)
                                        HandleFileSend();
                                    else
                                        FileTransferProtocol.SendString(stream, "ERROR:Not authenticated");
                                    break;
                                case CommandType.ListFiles:
                                    if (isAuthenticated)
                                        SendFileList();
                                    else
                                        FileTransferProtocol.SendString(stream, "ERROR:Not authenticated");
                                    break;
                                case CommandType.Disconnect:
                                    Disconnect();
                                    return;
                                default:
                                    FileTransferProtocol.SendString(stream, "ERROR:Unknown command");
                                    break;
                            }
                        }
                        else
                        {
                            FileTransferProtocol.SendString(stream, "ERROR:Invalid command");
                        }
                    }
                    catch (IOException ex)
                    {
                        serverForm.LogMessage($"📡 Connection error ({IPAddress}): {ex.Message}");
                        break;
                    }
                    catch (Exception ex)
                    {
                        serverForm.LogMessage($"⚠️ Client error ({IPAddress}): {ex.Message}");
                        try
                        {
                            FileTransferProtocol.SendString(stream, $"ERROR:{ex.Message}");
                        }
                        catch { }
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"❌ Client session error ({IPAddress}): {ex.Message}");
            }
            finally
            {
                serverForm.RemoveClient(this);
                Disconnect();
            }
        }

        private void HandleLogin()
        {
            try
            {
                string username = FileTransferProtocol.ReceiveString(stream);
                string password = FileTransferProtocol.ReceiveString(stream);

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    FileTransferProtocol.SendString(stream, "ERROR:Username and password required");
                    return;
                }

                isAuthenticated = auth.Authenticate(username, password, out UserRole role);

                if (isAuthenticated)
                {
                    Username = username;
                    Role = role;
                    FileTransferProtocol.SendString(stream, ResponseCode.LoginSuccess.ToString());
                    serverForm.LogMessage($"✅ User {Username} logged in successfully");
                    serverForm.UpdateClientList(this, Username);
                }
                else
                {
                    FileTransferProtocol.SendString(stream, ResponseCode.LoginFailed.ToString());
                    serverForm.LogMessage($"❌ Login failed for {username}");
                }
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"⚠️ Login error: {ex.Message}");
                try
                {
                    FileTransferProtocol.SendString(stream, $"ERROR:{ex.Message}");
                }
                catch { }
            }
        }

        private void HandleRegister()
        {
            try
            {
                string username = FileTransferProtocol.ReceiveString(stream);
                string password = FileTransferProtocol.ReceiveString(stream);

                // VALIDATION
                if (string.IsNullOrEmpty(username) || username.Length < 3)
                {
                    FileTransferProtocol.SendString(stream, "ERROR:Username must be at least 3 characters");
                    return;
                }

                if (string.IsNullOrEmpty(password) || password.Length < 6)
                {
                    FileTransferProtocol.SendString(stream, "ERROR:Password must be at least 6 characters");
                    return;
                }

                bool success = auth.Register(username, password);

                FileTransferProtocol.SendString(stream, success ?
                    ResponseCode.RegisterSuccess.ToString() :
                    ResponseCode.RegisterFailed.ToString());

                serverForm.LogMessage($"📝 Registration {(success ? "successful" : "failed")} for {username}");
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"⚠️ Register error: {ex.Message}");
                try
                {
                    FileTransferProtocol.SendString(stream, $"ERROR:{ex.Message}");
                }
                catch { }
            }
        }

        private void HandleFileReceive()
        {
            string filePath = "";

            try
            {
                // NHẬN TÊN FILE
                string originalFileName = FileTransferProtocol.ReceiveString(stream);

                // KIỂM TRA TÊN FILE
                if (string.IsNullOrEmpty(originalFileName) || originalFileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    FileTransferProtocol.SendString(stream, "ERROR:Invalid file name");
                    return;
                }

                // TẠO TÊN FILE AN TOÀN
                string safeFileName = GetSafeFileName(originalFileName);
                filePath = Path.Combine(storagePath, safeFileName);

                serverForm.LogMessage($"📤 Receiving file: {safeFileName} from {Username}");

                // THÊM: GỬI READY SIGNAL CHO CLIENT
                FileTransferProtocol.SendString(stream, "READY_TO_RECEIVE");

                // THÊM: KIỂM TRA DUNG LƯỢNG ĐĨA TRƯỚC
                DriveInfo drive = new DriveInfo(Path.GetPathRoot(filePath));
                if (drive.AvailableFreeSpace < MAX_FILE_SIZE)
                {
                    FileTransferProtocol.SendString(stream, "ERROR:Not enough disk space");
                    serverForm.LogMessage($"❌ Not enough disk space for {safeFileName}");
                    return;
                }

                // NHẬN FILE VỚI PROGRESS CALLBACK
                FileTransferProtocol.ReceiveFile(stream, filePath, progress =>
                {
                    if (progress % 25 == 0 || progress == 100)
                    {
                        serverForm.LogMessage($"📊 {safeFileName}: {progress}% complete");
                    }

                    // KIỂM TRA KẾT NỐI VẪN TỐT
                    if (!client.Connected)
                    {
                        throw new IOException("Connection lost during file transfer");
                    }
                });

                // KIỂM TRA FILE SAU KHI NHẬN
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Length == 0)
                {
                    File.Delete(filePath);
                    throw new Exception("Received empty file");
                }

                serverForm.LogMessage($"✅ File received successfully: {safeFileName} ({FormatFileSize(fileInfo.Length)})");

                FileTransferProtocol.SendString(stream, ResponseCode.FileReceived.ToString());
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"❌ File receive error: {ex.Message}");

                // XÓA FILE NẾU LỖI
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    try
                    {
                        File.Delete(filePath);
                        serverForm.LogMessage($"🗑️ Deleted incomplete file: {Path.GetFileName(filePath)}");
                    }
                    catch { }
                }

                try
                {
                    FileTransferProtocol.SendString(stream, $"ERROR:{ex.Message}");
                }
                catch { }
            }
        }

        private void HandleFileSend()
        {
            try
            {
                string fileName = FileTransferProtocol.ReceiveString(stream);

                // KIỂM TRA TÊN FILE
                if (string.IsNullOrEmpty(fileName))
                {
                    FileTransferProtocol.SendString(stream, "ERROR:File name required");
                    return;
                }

                // NGĂN CHẶN PATH TRAVERSAL
                if (fileName.Contains("..") || fileName.Contains("/") || fileName.Contains("\\"))
                {
                    FileTransferProtocol.SendString(stream, "ERROR:Invalid file name");
                    serverForm.LogMessage($"❌ Invalid file name attempt: {fileName}");
                    return;
                }

                string filePath = Path.Combine(storagePath, fileName);

                if (!File.Exists(filePath))
                {
                    FileTransferProtocol.SendString(stream, "FILE_NOT_FOUND");
                    serverForm.LogMessage($"❌ File not found: {fileName} requested by {Username}");
                    return;
                }

                // KIỂM TRA FILE SIZE TRƯỚC KHI GỬI
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Length > MAX_FILE_SIZE)
                {
                    FileTransferProtocol.SendString(stream, "ERROR:File too large");
                    serverForm.LogMessage($"❌ File too large: {fileName} ({FormatFileSize(fileInfo.Length)})");
                    return;
                }

                FileTransferProtocol.SendString(stream, "FILE_EXISTS");

                serverForm.LogMessage($"📥 Sending file: {fileName} ({FormatFileSize(fileInfo.Length)}) to {Username}");

                FileTransferProtocol.SendFile(stream, filePath, progress =>
                {
                    if (progress % 25 == 0 || progress == 100)
                    {
                        serverForm.LogMessage($"📤 {fileName}: {progress}% sent");
                    }

                    // KIỂM TRA KẾT NỐI
                    if (!client.Connected)
                    {
                        throw new IOException("Connection lost during file transfer");
                    }
                });

                serverForm.LogMessage($"✅ File sent successfully: {fileName}");
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"❌ File send error: {ex.Message}");
                try
                {
                    FileTransferProtocol.SendString(stream, $"ERROR:{ex.Message}");
                }
                catch { }
            }
        }

        private void SendFileList()
        {
            try
            {
                // KIỂM TRA THƯ MỤC TỒN TẠI
                if (!Directory.Exists(storagePath))
                {
                    FileTransferProtocol.SendString(stream, "ERROR:Storage directory not found");
                    return;
                }

                var files = Directory.GetFiles(storagePath);
                StringBuilder sb = new StringBuilder();

                foreach (var file in files)
                {
                    try
                    {
                        FileInfo info = new FileInfo(file);

                        // CHỈ GỬI FILE < MAX_FILE_SIZE
                        if (info.Length <= MAX_FILE_SIZE)
                        {
                            // GỬI TÊN FILE GỐC (BỎ TIMESTAMP NẾU CÓ)
                            string displayName = GetOriginalFileName(info.Name);
                            sb.AppendLine($"{displayName}|{info.Length}|{info.LastWriteTime:yyyy-MM-dd HH:mm:ss}");
                        }
                    }
                    catch (Exception ex)
                    {
                        serverForm.LogMessage($"⚠️ Error reading file info {file}: {ex.Message}");
                    }
                }

                string fileList = sb.ToString();
                if (string.IsNullOrEmpty(fileList.Trim()))
                {
                    fileList = "EMPTY";
                }

                FileTransferProtocol.SendString(stream, fileList);
                serverForm.LogMessage($"📋 Sent file list ({files.Length} files) to {Username}");
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"❌ Error sending file list: {ex.Message}");
                FileTransferProtocol.SendString(stream, "ERROR");
            }
        }

        private string GetSafeFileName(string fileName)
        {
            // XÓA CÁC KÝ TỰ KHÔNG HỢP LỆ
            string invalidChars = new string(Path.GetInvalidFileNameChars());
            foreach (char c in invalidChars)
            {
                fileName = fileName.Replace(c.ToString(), "_");
            }

            // THÊM TIMESTAMP ĐỂ TRÁNH TRÙNG
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);

            // GIỚI HẠN ĐỘ DÀI TÊN FILE
            if (nameWithoutExt.Length > 50)
            {
                nameWithoutExt = nameWithoutExt.Substring(0, 50);
            }

            return $"{nameWithoutExt}_{timestamp}{extension}";
        }

        private string GetOriginalFileName(string fileNameWithTimestamp)
        {
            // TRẢ VỀ TÊN GỐC NẾU FILE CÓ TIMESTAMP
            string nameWithoutExt = Path.GetFileNameWithoutExtension(fileNameWithTimestamp);
            string extension = Path.GetExtension(fileNameWithTimestamp);

            // KIỂM TRA CÓ DẠNG name_timestamp KHÔNG
            int lastUnderscore = nameWithoutExt.LastIndexOf('_');
            if (lastUnderscore > 0)
            {
                string possibleTimestamp = nameWithoutExt.Substring(lastUnderscore + 1);
                if (possibleTimestamp.Length == 15 && IsAllDigits(possibleTimestamp))
                {
                    return nameWithoutExt.Substring(0, lastUnderscore) + extension;
                }
            }

            return fileNameWithTimestamp;
        }

        private bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            double len = bytes;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        public void Disconnect()
        {
            try
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                    stream = null;
                }
                if (client != null)
                {
                    client.Close();
                    client = null;
                }

                serverForm.LogMessage($"🔌 Client disconnected: {Username ?? IPAddress}");
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"⚠️ Error during disconnect: {ex.Message}");
            }
        }
    }
}