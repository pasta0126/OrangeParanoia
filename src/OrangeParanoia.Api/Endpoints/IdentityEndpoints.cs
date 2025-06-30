using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class IdentityEndpoints
    {
        public static void MapIdentityEndpoints(this WebApplication app)
        {
            var utilityGroup = app.MapGroup("/identity").WithTags("Identity");

            utilityGroup.MapGet("/human", (IIdentityService identityService, bool withNobleTitle = false, bool withTitle = false, bool withMiddleName = false) =>
            {
                var result = identityService.GenerateHumanIdentity(withNobleTitle, withTitle, withMiddleName);
                return Results.Ok(result);
            });
        }
    }
}
