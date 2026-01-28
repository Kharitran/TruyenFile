using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace SharedLibrary.Protocol
{
    public static class FileTransferProtocol
    {
        public const int BufferSize = 8192;

        public static void SendString(NetworkStream stream, string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data ?? "");
            byte[] lengthBytes = BitConverter.GetBytes(bytes.Length);
            stream.Write(lengthBytes, 0, 4);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
        }

        public static string ReceiveString(NetworkStream stream)
        {
            byte[] lengthBytes = new byte[4];
            int read = stream.Read(lengthBytes, 0, 4);
            if (read < 4) throw new IOException("Connection lost while reading length");

            int length = BitConverter.ToInt32(lengthBytes, 0);
            if (length <= 0) return string.Empty;

            byte[] dataBytes = new byte[length];
            int totalRead = 0;
            while (totalRead < length)
            {
                int r = stream.Read(dataBytes, totalRead, length - totalRead);
                if (r == 0) throw new IOException("Connection lost while reading data");
                totalRead += r;
            }
            return Encoding.UTF8.GetString(dataBytes);
        }

        public static void SendFile(NetworkStream stream, string filePath, Action<int> progress = null)
        {
            FileInfo info = new FileInfo(filePath);
            SendString(stream, $"{info.Name}|{info.Length}");

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[BufferSize];
                long totalSent = 0;
                int bytesRead;
                while ((bytesRead = fs.Read(buffer, 0, BufferSize)) > 0)
                {
                    stream.Write(BitConverter.GetBytes(bytesRead), 0, 4);
                    stream.Write(buffer, 0, bytesRead);
                    totalSent += bytesRead;
                    progress?.Invoke((int)((totalSent * 100) / info.Length));
                }
                stream.Write(BitConverter.GetBytes(0), 0, 4); // End of file
            }
        }

        public static void ReceiveFile(NetworkStream stream, string savePath, Action<int> progress = null)
        {
            string metadata = ReceiveString(stream);
            string[] parts = metadata.Split('|');
            long fileSize = long.Parse(parts[1]);

            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                long totalReceived = 0;
                while (true)
                {
                    byte[] sizeBytes = new byte[4];
                    stream.Read(sizeBytes, 0, 4);
                    int chunkSize = BitConverter.ToInt32(sizeBytes, 0);
                    if (chunkSize == 0) break;

                    byte[] buffer = new byte[chunkSize];
                    int r = 0;
                    while (r < chunkSize)
                    {
                        int read = stream.Read(buffer, r, chunkSize - r);
                        r += read;
                    }
                    fs.Write(buffer, 0, chunkSize);
                    totalReceived += chunkSize;
                    progress?.Invoke((int)((totalReceived * 100) / fileSize));
                }
            }
        }
    }
}
