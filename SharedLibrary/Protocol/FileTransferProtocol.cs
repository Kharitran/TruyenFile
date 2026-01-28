using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace SharedLibrary.Protocol
{
    public static class FileTransferProtocol
    {
        // Constants
        public const int BufferSize = 8192; // 8KB
        public const int HeaderSize = 256;

        // Send string với length prefix
        public static void SendString(NetworkStream stream, string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] lengthBytes = BitConverter.GetBytes(bytes.Length);

            stream.Write(lengthBytes, 0, 4); // Gửi độ dài (4 bytes)
            stream.Write(bytes, 0, bytes.Length); // Gửi dữ liệu
            stream.Flush();
        }

        public static string ReceiveString(NetworkStream stream)
        {
            byte[] lengthBytes = new byte[4];
            int bytesRead = stream.Read(lengthBytes, 0, 4);

            if (bytesRead != 4)
                throw new IOException("Failed to read string length");

            int length = BitConverter.ToInt32(lengthBytes, 0);

            if (length <= 0 || length > 1024 * 1024) // Giới hạn 1MB
                throw new IOException($"Invalid string length: {length}");

            byte[] dataBytes = new byte[length];
            bytesRead = 0;

            while (bytesRead < length)
            {
                int read = stream.Read(dataBytes, bytesRead, length - bytesRead);
                if (read == 0)
                    throw new IOException("Connection closed while reading string");
                bytesRead += read;
            }

            return Encoding.UTF8.GetString(dataBytes);
        }

        // Send file với progress callback
        public static void SendFile(NetworkStream stream, string filePath, Action<int> progressCallback = null)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            string fileName = Path.GetFileName(filePath);
            long fileSize = fileInfo.Length;

            // Gửi metadata: fileName|fileSize
            SendString(stream, $"{fileName}|{fileSize}");

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[BufferSize];
                long totalBytesSent = 0;
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, BufferSize)) > 0)
                {
                    byte[] sizeBytes = BitConverter.GetBytes(bytesRead);
                    stream.Write(sizeBytes, 0, 4);

                    stream.Write(buffer, 0, bytesRead);

                    totalBytesSent += bytesRead;

                    if (progressCallback != null)
                    {
                        int progress = (int)((totalBytesSent * 100) / fileSize);
                        progressCallback(progress);
                    }

                    stream.Flush();
                }

                byte[] endBytes = BitConverter.GetBytes(0);
                stream.Write(endBytes, 0, 4);
            }
        }

        public static void ReceiveFile(NetworkStream stream, string savePath, Action<int> progressCallback = null)
        {
            string metadata = ReceiveString(stream);
            string[] parts = metadata.Split('|');

            if (parts.Length != 2)
                throw new FormatException("Invalid metadata format");

            string fileName = parts[0];
            long fileSize = long.Parse(parts[1]);

            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                long totalBytesReceived = 0;

                while (true)
                {
                    byte[] sizeBytes = new byte[4];
                    int bytesRead = stream.Read(sizeBytes, 0, 4);

                    if (bytesRead != 4)
                        throw new IOException("Failed to read chunk size");

                    int chunkSize = BitConverter.ToInt32(sizeBytes, 0);

                    if (chunkSize == 0)
                        break;

                    byte[] buffer = new byte[chunkSize];
                    bytesRead = 0;

                    while (bytesRead < chunkSize)
                    {
                        int read = stream.Read(buffer, bytesRead, chunkSize - bytesRead);
                        if (read == 0)
                            throw new IOException("Connection closed while reading chunk");
                        bytesRead += read;
                    }

                    fs.Write(buffer, 0, chunkSize);
                    totalBytesReceived += chunkSize;

                    if (progressCallback != null)
                    {
                        int progress = (int)((totalBytesReceived * 100) / fileSize);
                        progressCallback(progress);
                    }
                }

                if (fs.Length != fileSize)
                    throw new IOException($"File size mismatch. Expected: {fileSize}, Actual: {fs.Length}");
            }
        }
    }
}