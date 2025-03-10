using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class ProgressionEndpoints
    {
        public static void MapProgressionEndpoints(this WebApplication app)
        {
            var progressionGroup = app.MapGroup("/progression").WithTags("Progressions");

            progressionGroup.MapGet("/fibonacci", (IProgressionService service, int n) =>
                Results.Ok(service.GetFibonacci(n)));

            progressionGroup.MapGet("/jacobsthal", (IProgressionService service, int n) =>
                Results.Ok(service.GetJacobsthal(n)));

            progressionGroup.MapGet("/lucas", (IProgressionService service, int n) =>
                Results.Ok(service.GetLucas(n)));

            progressionGroup.MapGet("/pell", (IProgressionService service, int n) =>
                Results.Ok(service.GetPell(n)));

            progressionGroup.MapGet("/hofstadterq", (IProgressionService service, int n) =>
                Results.Ok(service.GetHofstadterQ(n)));

            progressionGroup.MapGet("/logisticmap", (IProgressionService service, int n) =>
                Results.Ok(service.GetLogisticMap(n)));

            progressionGroup.MapGet("/exotic", (IProgressionService service, int n) =>
                Results.Ok(service.GetExotic(n)));
        }
    }
}
