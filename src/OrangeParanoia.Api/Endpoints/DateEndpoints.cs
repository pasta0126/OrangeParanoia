using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class DateEndpoints
    {
        public static void MapDateEndpoints(this WebApplication app)
        {
            app.MapGet("/date/future-date", (IDateService dateService, string? mask) =>
                dateService.GetFutureDate(mask));

            app.MapGet("/date/past-date", (IDateService dateService, string? mask) =>
                dateService.GetPastDate(mask));
            
            app.MapGet("/date/future-time", (IDateService dateService, string? mask) =>
                dateService.GetFutureTime(mask));
            
            app.MapGet("/date/past-time", (IDateService dateService, string? mask) =>
                dateService.GetPastTime(mask));
            
            app.MapGet("/date/future-datetime", (IDateService dateService, string? mask) =>
                dateService.GetFutureDateTime(mask));
            
            app.MapGet("/date/past-datetime", (IDateService dateService, string? mask) =>
                dateService.GetPastDateTime(mask));
        }
    }
}
