using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class DateEndpoints
    {
        public static void MapDateEndpoints(this WebApplication app)
        {
            var dateGroup = app.MapGroup("/date").WithTags("Date");
            dateGroup.MapGet("/future", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetFutureDate(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });
            dateGroup.MapGet("/past", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetPastDate(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });

            var timeGroup = app.MapGroup("/time").WithTags("Time");
            timeGroup.MapGet("/future", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetFutureTime(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });
            timeGroup.MapGet("/past", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetPastTime(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });

            var dateTimeGroup = app.MapGroup("/datetime").WithTags("DateTime");
            dateTimeGroup.MapGet("/future", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetFutureDateTime(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });
            dateTimeGroup.MapGet("/past", (IDateService dateService, string? mask) =>
            {
                var result = dateService.GetPastDateTime(mask);
                if (result.StartsWith("Error:"))
                    return Results.BadRequest(result);
                return Results.Ok(result);
            });
        }
    }
}
