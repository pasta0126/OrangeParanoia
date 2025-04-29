using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class ImageEndpoints
    {
        public static void MapImageEndpoints(this WebApplication app)
        {
            var imageGroup = app.MapGroup("/image").WithTags("Image");

            imageGroup.MapGet("/bmp", (IImageService imageService, int width, int height, int tileSize = 50) =>
            {
                var imageBytes = imageService.GenerateRandomBitmap(width, height, tileSize);
                return Results.File(
                    fileContents: imageBytes,
                    contentType: "image/bmp",
                    fileDownloadName: $"image_{width}x{height}_{tileSize}.bmp"
                );
            })
            .Produces<byte[]>(StatusCodes.Status200OK, "image/bmp")
            .WithName("GetRandomBitmap");

            imageGroup.MapGet("/png/rgb", (IImageService imageService, int width, int height, int tileSize = 32, int delta = 30) =>
            {
                var pngBytes = imageService.GeneratePngRGB(width, height, tileSize, delta);
                return Results.File(pngBytes, "image/png",
                    fileDownloadName: $"image_rgb_{width}x{height}_{tileSize}_{delta}.png");
            })
            .Produces<byte[]>(StatusCodes.Status200OK, "image/png")
            .WithName("GetRandomPngRgb");

            imageGroup.MapGet("/png/hsv", (IImageService imageService, int width, int height, int tileSize = 32, float maxHueStep = 15f) =>
            {
                var pngBytes = imageService.GeneratePngHSV(width, height, tileSize, maxHueStep);
                return Results.File(pngBytes, "image/png",
                    fileDownloadName: $"image_hsv_{width}x{height}_{tileSize}_{maxHueStep:F1}.png");
            })
            .Produces<byte[]>(StatusCodes.Status200OK, "image/png")
            .WithName("GetRandomPngHsv");

        }
    }
}
