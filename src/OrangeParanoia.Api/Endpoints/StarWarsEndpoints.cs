using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class StarWarsEndpoints
    {
        public static void MapStarWarsEndpoints(this WebApplication app)
        {
            var starWarsGroup = app.MapGroup("/starwars").WithTags("StarWars");

            var jediGroup = starWarsGroup.MapGroup("/jedi");
            jediGroup.MapGet("/classic", (IStarWarsService svc, string firstName, string lastName, string motherName, string birthCity) =>
                Results.Ok(svc.JediNameClassic(firstName, lastName, motherName, birthCity)));

            jediGroup.MapGet("/realform", (IStarWarsService svc, string firstName, string lastName, string motherName, string birthCity) =>
                Results.Ok(svc.JediNameRealForm(firstName, lastName, motherName, birthCity)));

            jediGroup.MapGet("/2332", (IStarWarsService svc, string firstName, string lastName, string motherName, string birthCity) =>
                Results.Ok(svc.JediName2332(firstName, lastName, motherName, birthCity)));

            jediGroup.MapGet("/fromends", (IStarWarsService svc, string firstName, string lastName, string motherName, string birthCity) =>
                Results.Ok(svc.JediNameFromEnds(firstName, lastName, motherName, birthCity)));

            jediGroup.MapGet("/astrology", (IStarWarsService svc, string firstName, string lastName, string birthCity, string zodiacSign, string zodiacElement) =>
                Results.Ok(svc.JediNameAstrology(firstName, lastName, birthCity, zodiacSign, zodiacElement)));

            var sithGroup = starWarsGroup.MapGroup("/sith");
            sithGroup.MapGet("/classic", (IStarWarsService svc, string petName, string streetName) =>
                Results.Ok(svc.SithNameClassic(petName, streetName)));

            sithGroup.MapGet("/method1", (IStarWarsService svc, string realName, string emotion, string virtue) =>
                Results.Ok(svc.SithNameMethod1(realName, emotion, virtue)));

            sithGroup.MapGet("/method2", (IStarWarsService svc, string ambition, string realName, string weakness, string parentName) =>
                Results.Ok(svc.SithNameMethod2(ambition, realName, weakness, parentName)));

            sithGroup.MapGet("/method3", (IStarWarsService svc, string realName, string emotion) =>
                Results.Ok(svc.SithNameMethod3(realName, emotion)));
        }
    }
}
