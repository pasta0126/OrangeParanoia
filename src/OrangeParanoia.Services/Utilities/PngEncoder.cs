using System.IO.Compression;

namespace OrangeParanoia.Services.Utilities
{
    public static class PngEncoder
    {
        public static void SavePng(byte[] pixelData, int width, int height, string filePath)
        {
            using var stream = File.OpenWrite(filePath);
            WriteSignature(stream);
            WriteIHDR(stream, width, height);
            WriteIDAT(stream, pixelData, width, height);
            WriteIEND(stream);
        }

        static void WriteSignature(Stream s)
        {
            s.Write(
            [
                0x89, 0x50, 0x4E, 0x47,
                0x0D, 0x0A, 0x1A, 0x0A
            ]);
        }

        static void WriteIHDR(Stream s, int width, int height)
        {
            Span<byte> ihdrData = stackalloc byte[13];

            WriteBigEndian(ihdrData, 0, width);
            WriteBigEndian(ihdrData, 4, height);

            ihdrData[8] = 8;
            ihdrData[9] = 6;
            ihdrData[10] = 0;
            ihdrData[11] = 0;
            ihdrData[12] = 0;

            WriteChunk(s, "IHDR", ihdrData);
        }

        static void WriteIDAT(Stream s, byte[] pixels, int width, int height)
        {
            int rowLength = width * 4;
            int stride = rowLength + 1;
            byte[] raw = new byte[height * stride];

            for (int y = 0; y < height; y++)
            {
                int destRow = y * stride;
                raw[destRow] = 0;
                Array.Copy(pixels, y * rowLength, raw, destRow + 1, rowLength);
            }

            using var msCompressed = new MemoryStream();
            using (var zs = new ZLibStream(msCompressed, CompressionLevel.Fastest, leaveOpen: true))
            {
                zs.Write(raw, 0, raw.Length);
            }

            byte[] compressed = msCompressed.ToArray();

            WriteChunk(s, "IDAT", compressed);
        }

        static void WriteIEND(Stream s)
        {
            WriteChunk(s, "IEND", Array.Empty<byte>());
        }

        static void WriteChunk(Stream s, string chunkType, ReadOnlySpan<byte> data)
        {
            byte[] typeBytes = System.Text.Encoding.ASCII.GetBytes(chunkType);
            int length = data.Length;

            WriteBigEndian(s, length);

            s.Write(typeBytes, 0, 4);
            s.Write(data);

            uint crc = ComputeCrc(typeBytes, data);

            WriteBigEndian(s, (int)crc);
        }

        static uint ComputeCrc(ReadOnlySpan<byte> typeBytes, ReadOnlySpan<byte> data)
        {
            var crc32 = new Crc32();

            crc32.Append(typeBytes);
            crc32.Append(data);

            return crc32.Hash;
        }

        static void WriteBigEndian(Stream s, int value)
        {
            Span<byte> buffer = stackalloc byte[4];

            WriteBigEndian(buffer, 0, value);

            s.Write(buffer);
        }

        static void WriteBigEndian(Span<byte> buffer, int offset, int value)
        {
            buffer[offset + 0] = (byte)((value >> 24) & 0xFF);
            buffer[offset + 1] = (byte)((value >> 16) & 0xFF);
            buffer[offset + 2] = (byte)((value >> 8) & 0xFF);
            buffer[offset + 3] = (byte)(value & 0xFF);
        }

        private class Crc32
        {
            const uint Polynomial = 0xEDB88320u;
            readonly uint[] table;
            uint current;

            public Crc32()
            {
                table = new uint[256];

                for (uint i = 0; i < 256; i++)
                {
                    uint crc = i;

                    for (int j = 0; j < 8; j++)
                    {
                        if ((crc & 1) != 0)
                            crc = (crc >> 1) ^ Polynomial;
                        else
                            crc >>= 1;
                    }

                    table[i] = crc;
                }

                current = 0xFFFFFFFFu;
            }

            public void Append(ReadOnlySpan<byte> data)
            {
                foreach (byte b in data)
                {
                    uint temp = (current ^ b) & 0xFF;

                    current = (current >> 8) ^ table[temp];
                }
            }

            public uint Hash
            {
                get { return ~current; }
            }
        }
    }
}
