using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Server.Core
{
    public class FileTransferHandler
    {
        public static string CalculateMD5(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public static bool ValidateFile(byte[] data, string checksum)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(data);
                var calculated = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                return calculated == checksum;
            }
        }
    }
}