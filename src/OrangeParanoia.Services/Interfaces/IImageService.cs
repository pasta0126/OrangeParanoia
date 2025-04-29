namespace OrangeParanoia.Services.Interfaces
{
    public interface IImageService
    {
        public byte[] GenerateRandomBitmap(int width, int height, int tileSize = 32);
        public byte[] GeneratePngRGB(int width, int height, int tileSize = 32, int delta = 30);
        public byte[] GeneratePngHSV(int width, int height, int tileSize = 32, float maxHueStep = 15f);
    }
}
