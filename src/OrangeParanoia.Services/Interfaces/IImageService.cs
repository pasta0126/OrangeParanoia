namespace OrangeParanoia.Services.Interfaces
{
    public interface IImageService
    {
        public byte[] GenerateRandomBitmap(int height, int width, int tileSize = 32);
    }
}
