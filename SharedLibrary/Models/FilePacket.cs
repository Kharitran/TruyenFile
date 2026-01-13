using System;

namespace SharedLibrary.Models
{
    [Serializable]
    public class FilePacket
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public byte[] FileData { get; set; }
        public int PacketNumber { get; set; }
        public int TotalPackets { get; set; }
        public string Checksum { get; set; }
    }
}