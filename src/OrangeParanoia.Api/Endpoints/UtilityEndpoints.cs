using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class UtilityEndpoints
    {
        public static void MapUtilityEndpoints(this WebApplication app)
        {
            var utilityGroup = app.MapGroup("/utility").WithTags("Utility");

            utilityGroup.MapGet("/hexcolor", (IUtilityService utilityService, string? input) =>
                utilityService.GetHexColor(input ?? string.Empty));

            utilityGroup.MapGet("/hexcolor2", (IUtilityService utilityService, string? input) =>
                utilityService.GetHexColor2(input ?? string.Empty));

            utilityGroup.MapGet("/rgbcolor", (IUtilityService utilityService, string? input) =>
                utilityService.GetRgbColor(input ?? string.Empty));

            utilityGroup.MapGet("/rgba", (IUtilityService utilityService, string? input, double? alpha) =>
                utilityService.GetRgbaColor(input ?? string.Empty, alpha ?? 1.0));
        }
    }
}
