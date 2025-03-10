using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class ArrayEndpoints
    {
        public static void MapArrayEndpoints(this WebApplication app)
        {
            var arrayGroup = app.MapGroup("/array").WithTags("Arrays");

            arrayGroup.MapGet("/random", (IArrayService arrayService, string[] items) =>
            {
                var randomValue = arrayService.GetRandomValue(items);
                return Results.Ok(randomValue);
            });
        }
    }
}
