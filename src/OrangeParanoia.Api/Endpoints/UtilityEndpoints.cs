using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class UtilityEndpoints
    {
        public static void MapUtilityEndpoints(this WebApplication app)
        {
            app.MapGet("/utility/hexcolor", (IUtilityService utilityService, string? input) =>
                utilityService.GetHexColor(input ?? string.Empty));

            app.MapGet("/utility/hexcolor2", (IUtilityService utilityService, string? input) =>
                utilityService.GetHexColor2(input ?? string.Empty));

            app.MapGet("/utility/rgbcolor", (IUtilityService utilityService, string? input) =>
                utilityService.GetRgbColor(input ?? string.Empty));

            app.MapGet("/utility/rgba", (IUtilityService utilityService, string? input, double? alpha) =>
                utilityService.GetRgbaColor(input ?? string.Empty, alpha ?? 1.0));
        }
    }
}
