using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class ImageEndpoints
    {
        public static void MapImageEndpoints(this WebApplication app)
        {
            var imageGroup = app.MapGroup("/image").WithTags("Image");

            imageGroup.MapGet("/bitmap", (IImageService imageService, int height, int width, int tileSize = 50) =>
            {
                var imageBytes = imageService.GenerateRandomBitmap(height, width, tileSize);
                return Results.File(
                    fileContents: imageBytes,
                    contentType: "image/bmp",
                    fileDownloadName: $"image_{width}x{height}_{tileSize}.bmp"
                );
            })
            .Produces<byte[]>(StatusCodes.Status200OK, "image/bmp")
            .WithName("GetRandomBitmap");
        }
    }
}
