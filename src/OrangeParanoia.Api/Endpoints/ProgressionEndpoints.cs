using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class ProgressionEndpoints
    {
        public static void MapProgressionEndpoints(this WebApplication app)
        {
            app.MapGet("/progression/fibonacci", (IProgressionService service, int n) =>
                Results.Ok(service.GetFibonacci(n)));

            app.MapGet("/progression/jacobsthal", (IProgressionService service, int n) =>
                Results.Ok(service.GetJacobsthal(n)));

            app.MapGet("/progression/lucas", (IProgressionService service, int n) =>
                Results.Ok(service.GetLucas(n)));

            app.MapGet("/progression/pell", (IProgressionService service, int n) =>
                Results.Ok(service.GetPell(n)));

            app.MapGet("/progression/hofstadterq", (IProgressionService service, int n) =>
                Results.Ok(service.GetHofstadterQ(n)));

            app.MapGet("/progression/logisticmap", (IProgressionService service, int n) =>
                Results.Ok(service.GetLogisticMap(n)));

            app.MapGet("/progression/exotic", (IProgressionService service, int n) =>
                Results.Ok(service.GetExotic(n)));
        }
    }
}
