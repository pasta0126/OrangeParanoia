using System.IO.Compression;
using System.Text;

namespace OrangeParanoia.Services.Utilities
{
    public static class PngEncoder
    {
        private static readonly byte[] PngSignature = [137, 80, 78, 71, 13, 10, 26, 10];

        public static byte[] Encode(byte[] rgb, int width, int height)
        {
            if (rgb.Length != width * height * 3)
                throw new ArgumentException("El buffer debe ser width*height*3 bytes.");

            using var ms = new MemoryStream();
            ms.Write(PngSignature, 0, PngSignature.Length);

            var ihdr = new byte[13];
            WriteInt32BigEndian(ihdr, 0, width);
            WriteInt32BigEndian(ihdr, 4, height);
            ihdr[8] = 8;
            ihdr[9] = 2;
            ihdr[10] = 0;
            ihdr[11] = 0;
            ihdr[12] = 0;
            WriteChunk(ms, "IHDR", ihdr);

            byte[] idatData;
            using (var cmp = new MemoryStream())
            {
                using (var ds = new DeflateStream(cmp, CompressionLevel.Optimal, leaveOpen: true))
                {
                    int stride = width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        ds.WriteByte(0);
                        int offset = y * stride;
                        ds.Write(rgb, offset, stride);
                    }
                }
                idatData = cmp.ToArray();
            }
            WriteChunk(ms, "IDAT", idatData);

            WriteChunk(ms, "IEND", Array.Empty<byte>());

            return ms.ToArray();
        }

        private static void WriteChunk(Stream s, string type, byte[] data)
        {
            var typeBytes = Encoding.ASCII.GetBytes(type);
            WriteInt32BigEndian(s, data.Length);
            s.Write(typeBytes, 0, 4);
            s.Write(data, 0, data.Length);
            uint crc = Crc32(typeBytes, data);
            WriteUInt32BigEndian(s, crc);
        }

        private static void WriteInt32BigEndian(Stream s, int value)
        {
            var buf = new byte[4];
            WriteInt32BigEndian(buf, 0, value);
            s.Write(buf, 0, buf.Length);
        }

        private static void WriteInt32BigEndian(byte[] buf, int offset, int value)
        {
            buf[offset + 0] = (byte)((value >> 24) & 0xFF);
            buf[offset + 1] = (byte)((value >> 16) & 0xFF);
            buf[offset + 2] = (byte)((value >> 8) & 0xFF);
            buf[offset + 3] = (byte)(value & 0xFF);
        }

        private static void WriteUInt32BigEndian(Stream s, uint value)
        {
            var buf = new byte[4];
            buf[0] = (byte)((value >> 24) & 0xFF);
            buf[1] = (byte)((value >> 16) & 0xFF);
            buf[2] = (byte)((value >> 8) & 0xFF);
            buf[3] = (byte)(value & 0xFF);
            s.Write(buf, 0, buf.Length);
        }

        private static uint Crc32(byte[] type, byte[] data)
        {
            const uint Poly = 0xEDB88320;
            uint[] table = new uint[256];
            for (uint i = 0; i < 256; i++)
            {
                uint c = i;
                for (int j = 0; j < 8; j++)
                    c = (c & 1) != 0 ? Poly ^ (c >> 1) : (c >> 1);
                table[i] = c;
            }

            uint crc = 0xFFFFFFFFu;
            foreach (byte b in type)
                crc = table[(crc ^ b) & 0xFF] ^ (crc >> 8);
            foreach (byte b in data)
                crc = table[(crc ^ b) & 0xFF] ^ (crc >> 8);
            return crc ^ 0xFFFFFFFFu;
        }
    }
}
