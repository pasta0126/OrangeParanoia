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
                    contentType: "image/bmp"
                );
            })
            .Produces<byte[]>(StatusCodes.Status200OK, "image/bmp")
            .WithName("GetRandomBitmapInline");

            imageGroup.MapGet("/bmp/download", (IImageService imageService, int width, int height, int tileSize = 50) =>
            {
                var imageBytes = imageService.GenerateRandomBitmap(width, height, tileSize);
                return Results.File(
                    fileContents: imageBytes,
                    contentType: "image/bmp",
                    fileDownloadName: $"image_{width}x{height}_{tileSize}.bmp"
                );
            })
            .Produces<byte[]>(StatusCodes.Status200OK, "image/bmp")
            .WithName("GetRandomBitmapDownload");

            imageGroup.MapGet("/png/rgb", (IImageService imageService, int width, int height, int tileSize = 32, int delta = 30) =>
            {
                var pngBytes = imageService.GeneratePngRGBNative(width, height, tileSize, delta);
                return Results.File(
                    fileContents: pngBytes,
                    contentType: "image/png"
                );
            })
            .Produces<byte[]>(StatusCodes.Status200OK, "image/png")
            .WithName("GetNativePngRgbInline");

            imageGroup.MapGet("/png/rgb/download", (IImageService imageService, int width, int height, int tileSize = 32, int delta = 30) =>
            {
                var pngBytes = imageService.GeneratePngRGBNative(width, height, tileSize, delta);
                return Results.File(
                    fileContents: pngBytes,
                    contentType: "image/png",
                    fileDownloadName: $"image_native_rgb_{width}x{height}_{tileSize}_{delta}.png"
                );
            })
            .Produces<byte[]>(StatusCodes.Status200OK, "image/png")
            .WithName("GetNativePngRgbDownload");

            imageGroup.MapGet("/png/hsv", (IImageService imageService, int width, int height, int tileSize = 32, float maxHueStep = 15f) =>
            {
                var pngBytes = imageService.GeneratePngHSVNative(width, height, tileSize, maxHueStep);
                return Results.File(
                    fileContents: pngBytes,
                    contentType: "image/png"
                );
            })
            .Produces<byte[]>(StatusCodes.Status200OK, "image/png")
            .WithName("GetNativePngHsvInline");

            imageGroup.MapGet("/png/hsv/download", (IImageService imageService, int width, int height, int tileSize = 32, float maxHueStep = 15f) =>
            {
                var pngBytes = imageService.GeneratePngHSVNative(width, height, tileSize, maxHueStep);
                return Results.File(
                    fileContents: pngBytes,
                    contentType: "image/png",
                    fileDownloadName: $"image_native_hsv_{width}x{height}_{tileSize}_{maxHueStep:F1}.png"
                );
            })
            .Produces<byte[]>(StatusCodes.Status200OK, "image/png")
            .WithName("GetNativePngHsvDownload");
        }
    }
}
