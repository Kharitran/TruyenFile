using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using SharedLibrary.Enums;
using SharedLibrary.Models;

namespace Client.Services
{
    public class FileTransferClient
    {
        private TcpClient client;
        private NetworkStream stream;
        private BinaryFormatter formatter;
        private bool isConnected = false;

        public event Action<int> UploadProgressChanged;
        public event Action<int> DownloadProgressChanged;
        public event Action<string> StatusChanged;

        public bool Connect(string ip, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(ip, port);
                stream = client.GetStream();
                formatter = new BinaryFormatter();
                isConnected = true;

                // Kích hoạt event
                StatusChanged?.Invoke($"Connected to {ip}:{port}");
                return true;
            }
            catch (Exception ex)
            {
                StatusChanged?.Invoke($"Connection failed: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (isConnected)
                {
                    formatter.Serialize(stream, CommandType.Disconnect);
                    StatusChanged?.Invoke("Disconnected from server");
                }
            }
            catch (Exception ex)
            {
                StatusChanged?.Invoke($"Error disconnecting: {ex.Message}");
            }
            finally
            {
                try
                {
                    client?.Close();
                }
                catch { }
                isConnected = false;
            }
        }

        public async Task<bool> UploadFileAsync(string filePath)
        {
            return await Task.Run(() => UploadFile(filePath));
        }

        private bool UploadFile(string filePath)
        {
            if (!isConnected || !File.Exists(filePath))
            {
                StatusChanged?.Invoke("Not connected or file does not exist");
                return false;
            }

            try
            {
                StatusChanged?.Invoke($"Starting upload: {Path.GetFileName(filePath)}");

                var fileInfo = new FileInfo(filePath);
                var buffer = new byte[8192];
                var totalPackets = (int)Math.Ceiling((double)fileInfo.Length / buffer.Length);

                formatter.Serialize(stream, CommandType.SendFile);

                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    int packetNumber = 1;
                    int bytesRead;

                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        var packet = new FilePacket
                        {
                            FileName = Path.GetFileName(filePath),
                            FileSize = fileInfo.Length,
                            FileData = new byte[bytesRead],
                            PacketNumber = packetNumber,
                            TotalPackets = totalPackets
                        };

                        Array.Copy(buffer, packet.FileData, bytesRead);

                        formatter.Serialize(stream, packet);

                        var progress = (int)formatter.Deserialize(stream);
                        UploadProgressChanged?.Invoke(progress);

                        packetNumber++;
                    }
                }

                StatusChanged?.Invoke("Upload completed successfully");
                return true;
            }
            catch (Exception ex)
            {
                StatusChanged?.Invoke($"Upload failed: {ex.Message}");
                return false;
            }
        }

        // Thêm method để download file
        public async Task<bool> DownloadFileAsync(string fileName, string savePath)
        {
            return await Task.Run(() => DownloadFile(fileName, savePath));
        }

        private bool DownloadFile(string fileName, string savePath)
        {
            if (!isConnected)
            {
                StatusChanged?.Invoke("Not connected to server");
                return false;
            }

            try
            {
                StatusChanged?.Invoke($"Requesting file: {fileName}");

                formatter.Serialize(stream, CommandType.RequestFile);
                formatter.Serialize(stream, fileName);

                var fileExists = (bool)formatter.Deserialize(stream);
                if (!fileExists)
                {
                    StatusChanged?.Invoke("File not found on server");
                    return false;
                }

                using (var fs = new FileStream(savePath, FileMode.Create))
                {
                    while (true)
                    {
                        var packet = (FilePacket)formatter.Deserialize(stream);
                        fs.Write(packet.FileData, 0, packet.FileData.Length);

                        var progress = (int)((packet.PacketNumber * 100.0) / packet.TotalPackets);
                        DownloadProgressChanged?.Invoke(progress);

                        if (packet.PacketNumber == packet.TotalPackets)
                            break;
                    }
                }

                StatusChanged?.Invoke($"Download completed: {fileName}");
                return true;
            }
            catch (Exception ex)
            {
                StatusChanged?.Invoke($"Download failed: {ex.Message}");
                return false;
            }
        }

        // Thêm method để lấy danh sách file
        public async Task<string[]> GetFileListAsync()
        {
            return await Task.Run(() => GetFileList());
        }

        private string[] GetFileList()
        {
            if (!isConnected)
            {
                StatusChanged?.Invoke("Not connected to server");
                return new string[0];
            }

            try
            {
                formatter.Serialize(stream, CommandType.ListFiles);
                return (string[])formatter.Deserialize(stream);
            }
            catch (Exception ex)
            {
                StatusChanged?.Invoke($"Error getting file list: {ex.Message}");
                return new string[0];
            }
        }
    }
}