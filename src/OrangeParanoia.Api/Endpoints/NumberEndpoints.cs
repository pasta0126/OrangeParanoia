using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class NumberEndpoints
    {
        public static void MapNumberEndpoints(this WebApplication app)
        {
            var numberGroup = app.MapGroup("/number").WithTags("Numbers");

            numberGroup.MapGet("/random/int", (INumberService numberService, int? min, int? max) =>
                numberService.GetRandomNumber<int>(min, max));

            numberGroup.MapGet("/random/decimal", (INumberService numberService, decimal? min, decimal? max) =>
                numberService.GetRandomNumber<decimal>(min, max));

            numberGroup.MapGet("/random/double", (INumberService numberService, double? min, double? max) =>
                numberService.GetRandomNumber<double>(min, max));

            numberGroup.MapGet("/random/float", (INumberService numberService, float? min, float? max) =>
                numberService.GetRandomNumber<float>(min, max));

            numberGroup.MapGet("/random/decimal-range", (INumberService numberService, HttpRequest request) =>
            {
                int precision = 2;
                decimal min = 0;
                decimal max = 1;

                if (request.Query.TryGetValue("precision", out var precisionValue) &&
                    int.TryParse(precisionValue, out var p))
                {
                    precision = p;
                }
                if (request.Query.TryGetValue("min", out var minValue) &&
                    decimal.TryParse(minValue, out var m))
                {
                    min = m;
                }
                if (request.Query.TryGetValue("max", out var maxValue) &&
                    decimal.TryParse(maxValue, out var M))
                {
                    max = M;
                }

                return numberService.GetRandomDecimalInRange(min, max, precision);
            });
        }
    }
}
