using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using SharedLibrary.Enums;
using SharedLibrary.Models;


namespace Server.Core
{
    public class ClientSession
    {
        private TcpClient client;
        private NetworkStream stream;
        private BinaryFormatter formatter;
        private string storagePath;
        private Authentication auth;
        private ServerForm serverForm;
        private bool isAuthenticated = false;

        public string Username { get; private set; }
        public string IPAddress { get; private set; }
        public UserRole Role { get; private set; }

        public ClientSession(TcpClient client, string storagePath, Authentication auth, ServerForm serverForm)
        {
            this.client = client;
            this.stream = client.GetStream();
            this.formatter = new BinaryFormatter();
            this.storagePath = storagePath;
            this.auth = auth;
            this.serverForm = serverForm;
            this.IPAddress = ((System.Net.IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

            Directory.CreateDirectory(storagePath);
        }

        public void HandleClient()
        {
            try
            {
                while (client.Connected)
                {
                    if (stream.DataAvailable)
                    {
                        var command = (CommandType)formatter.Deserialize(stream);

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
                                break;
                            case CommandType.RequestFile:
                                if (isAuthenticated)
                                    HandleFileSend();
                                break;
                            case CommandType.ListFiles:
                                if (isAuthenticated)
                                    SendFileList();
                                break;
                            case CommandType.Disconnect:
                                Disconnect();
                                return;
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"Client error ({IPAddress}): {ex.Message}");
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
                var user = (User)formatter.Deserialize(stream);
                isAuthenticated = auth.Authenticate(user.Username, user.Password, out UserRole role);

                if (isAuthenticated)
                {
                    Username = user.Username;
                    Role = role;
                    formatter.Serialize(stream, ResponseCode.LoginSuccess);
                    serverForm.LogMessage($"User {Username} logged in successfully");
                    serverForm.UpdateClientList();
                }
                else
                {
                    formatter.Serialize(stream, ResponseCode.LoginFailed);
                }
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"Login error: {ex.Message}");
            }
        }

        private void HandleRegister()
        {
            try
            {
                var user = (User)formatter.Deserialize(stream);
                bool success = auth.Register(user.Username, user.Password);

                formatter.Serialize(stream, success ? ResponseCode.RegisterSuccess : ResponseCode.RegisterFailed);
                serverForm.LogMessage($"Registration {(success ? "successful" : "failed")} for {user.Username}");
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"Register error: {ex.Message}");
            }
        }

        private void HandleFileReceive()
        {
            try
            {
                var packet = (FilePacket)formatter.Deserialize(stream);
                string filePath = Path.Combine(storagePath, packet.FileName);

                if (packet.PacketNumber == 1)
                {
                    // First packet, create or truncate file
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        fs.Write(packet.FileData, 0, packet.FileData.Length);
                    }
                }
                else
                {
                    // Append to existing file
                    using (var fs = new FileStream(filePath, FileMode.Append))
                    {
                        fs.Write(packet.FileData, 0, packet.FileData.Length);
                    }
                }

                // Send progress update
                var progress = (int)((packet.PacketNumber * 100.0) / packet.TotalPackets);
                formatter.Serialize(stream, progress);

                if (packet.PacketNumber == packet.TotalPackets)
                {
                    serverForm.LogMessage($"File received: {packet.FileName} ({packet.FileSize} bytes)");
                }
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"File receive error: {ex.Message}");
            }
        }

        private void SendFileList()
        {
            try
            {
                var files = Directory.GetFiles(storagePath);
                formatter.Serialize(stream, files);
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"Error sending file list: {ex.Message}");
            }
        }

        private void HandleFileSend()
        {
            try
            {
                var fileName = (string)formatter.Deserialize(stream);
                string filePath = Path.Combine(storagePath, fileName);

                if (!File.Exists(filePath))
                {
                    formatter.Serialize(stream, false);
                    return;
                }

                formatter.Serialize(stream, true);

                var fileInfo = new FileInfo(filePath);
                var fileSize = fileInfo.Length;
                var buffer = new byte[8192]; // 8KB chunks
                var totalPackets = (int)Math.Ceiling((double)fileSize / buffer.Length);

                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    int packetNumber = 1;
                    int bytesRead;

                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        var packet = new FilePacket
                        {
                            FileName = fileName,
                            FileSize = fileSize,
                            FileData = buffer.Take(bytesRead).ToArray(),
                            PacketNumber = packetNumber,
                            TotalPackets = totalPackets
                        };

                        formatter.Serialize(stream, packet);
                        packetNumber++;
                    }
                }

                serverForm.LogMessage($"File sent: {fileName}");
            }
            catch (Exception ex)
            {
                serverForm.LogMessage($"File send error: {ex.Message}");
            }
        }

        public void Disconnect()
        {
            try
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
            catch { }
        }
    }
}