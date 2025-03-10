using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class DateEndpoints
    {
        public static void MapDateEndpoints(this WebApplication app)
        {
            app.MapGet("/date/future", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetFutureDate(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });

            app.MapGet("/date/past", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetPastDate(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });

            app.MapGet("/time/future", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetFutureTime(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });

            app.MapGet("/time/past", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetPastTime(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });

            app.MapGet("/datetime/future", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetFutureDateTime(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });

            app.MapGet("/datetime/past", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetPastDateTime(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });
        }
    }
}
