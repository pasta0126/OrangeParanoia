using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Services
{
    public class ImageService : IImageService
    {
        private readonly Random _random = new();

        public byte[] GenerateRandomBitmap(
            int width,
            int height,
            int tileSize = 32)
        {
            const int bytesPerPixel = 3;
            var buffer = new (byte B, byte G, byte R)[height, width];

            for (int y = 0; y < height;)
            {
                int tileH = Math.Min(tileSize, height - y);

                for (int x = 0; x < width;)
                {
                    int tileW = Math.Min(tileSize, width - x);

                    byte r = (byte)_random.Next(256);
                    byte g = (byte)_random.Next(256);
                    byte b = (byte)_random.Next(256);

                    for (int yy = y; yy < y + tileH; yy++)
                        for (int xx = x; xx < x + tileW; xx++)
                            buffer[yy, xx] = (b, g, r);

                    x += tileW;
                }

                y += tileH;
            }

            int stride = ((width * bytesPerPixel + 3) / 4) * 4;
            int pixelDataSize = stride * height;
            int fileHeaderSize = 14;
            int infoHeaderSize = 40;
            int fileSize = fileHeaderSize + infoHeaderSize + pixelDataSize;

            using var ms = new MemoryStream();
            using var bw = new BinaryWriter(ms);

            bw.Write((ushort)0x4D42);
            bw.Write(fileSize);
            bw.Write((ushort)0);
            bw.Write((ushort)0);
            bw.Write(fileHeaderSize + infoHeaderSize);

            bw.Write(infoHeaderSize);
            bw.Write(width);
            bw.Write(height);
            bw.Write((ushort)1);
            bw.Write((ushort)(bytesPerPixel * 8));
            bw.Write(0);
            bw.Write(pixelDataSize);
            bw.Write(0);
            bw.Write(0);
            bw.Write(0);
            bw.Write(0);

            byte[] padding = new byte[stride - width * bytesPerPixel];

            for (int row = height - 1; row >= 0; row--)
            {
                for (int col = 0; col < width; col++)
                {
                    var (bb, gg, rr) = buffer[row, col];
                    bw.Write(bb);
                    bw.Write(gg);
                    bw.Write(rr);
                }
                if (padding.Length > 0)
                    bw.Write(padding);
            }

            bw.Flush();
            return ms.ToArray();
        }
    }
}
