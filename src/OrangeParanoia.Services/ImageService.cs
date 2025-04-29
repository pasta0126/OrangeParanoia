using OrangeParanoia.Services.Interfaces;
using OrangeParanoia.Services.Utilities;

namespace OrangeParanoia.Services
{
    public class ImageService : IImageService
    {
        private readonly Random _random = new();
        private static int Clamp(int v, int lo, int hi) => v < lo ? lo : v > hi ? hi : v;

        public byte[] GenerateRandomBitmap(int width, int height, int tileSize = 32)
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

        public byte[] GeneratePngRGB(int width, int height, int tileSize = 32, int delta = 30)
        {
            var buffer = new (byte B, byte G, byte R)[height, width];
            var rnd = new Random();

            int prevR = rnd.Next(256), prevG = rnd.Next(256), prevB = rnd.Next(256);

            for (int y = 0; y < height;)
            {
                int h = Math.Min(tileSize, height - y);
                for (int x = 0; x < width;)
                {
                    prevR = Clamp(prevR + rnd.Next(-delta, delta + 1), 0, 255);
                    prevG = Clamp(prevG + rnd.Next(-delta, delta + 1), 0, 255);
                    prevB = Clamp(prevB + rnd.Next(-delta, delta + 1), 0, 255);

                    for (int yy = y; yy < y + h; yy++)
                        for (int xx = x; xx < x + Math.Min(tileSize, width - x); xx++)
                            buffer[yy, xx] = ((byte)prevB, (byte)prevG, (byte)prevR);

                    x += tileSize;
                }
                y += tileSize;
            }

            var rgb = new byte[width * height * 3];
            int idx = 0;
            for (int yy = 0; yy < height; yy++)
                for (int xx = 0; xx < width; xx++)
                {
                    var (b, g, r) = buffer[yy, xx];
                    rgb[idx++] = r;
                    rgb[idx++] = g;
                    rgb[idx++] = b;
                }

            return PngEncoder.Encode(rgb, width, height);
        }

        public byte[] GeneratePngHSV(int width, int height, int tileSize = 32, float maxHueStep = 15f)
        {
            var buffer = new (byte B, byte G, byte R)[height, width];
            var rnd = new Random();

            float hue = (float)(rnd.NextDouble() * 360);
            const float sat = 0.6f, val = 0.9f;

            for (int y = 0; y < height;)
            {
                int h = Math.Min(tileSize, height - y);
                for (int x = 0; x < width;)
                {
                    hue = (hue + (float)(rnd.NextDouble() * 2 - 1) * maxHueStep + 360) % 360;
                    var (r, g, b) = HsvToRgb(hue, sat, val);

                    for (int yy = y; yy < y + h; yy++)
                        for (int xx = x; xx < x + Math.Min(tileSize, width - x); xx++)
                            buffer[yy, xx] = (b, g, r);

                    x += tileSize;
                }
                y += tileSize;
            }

            var rgb = new byte[width * height * 3];
            int idx = 0;
            for (int yy = 0; yy < height; yy++)
                for (int xx = 0; xx < width; xx++)
                {
                    var (b, g, r) = buffer[yy, xx];
                    rgb[idx++] = r;
                    rgb[idx++] = g;
                    rgb[idx++] = b;
                }

            return PngEncoder.Encode(rgb, width, height);
        }

        private static (byte r, byte g, byte b) HsvToRgb(float h, float s, float v)
        {
            float c = v * s;
            float x = c * (1 - MathF.Abs((h / 60f) % 2f - 1));
            float m = v - c;
            float rp = 0, gp = 0, bp = 0;

            if (h < 60) { rp = c; gp = x; }
            else if (h < 120) { rp = x; gp = c; }
            else if (h < 180) { gp = c; bp = x; }
            else if (h < 240) { gp = x; bp = c; }
            else if (h < 300) { rp = x; bp = c; }
            else { rp = c; bp = x; }

            return (
                r: (byte)((rp + m) * 255),
                g: (byte)((gp + m) * 255),
                b: (byte)((bp + m) * 255)
            );
        }
    }
}
