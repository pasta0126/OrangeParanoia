using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Services
{
    public class NumberService : INumberService
    {
        private static readonly Random _random = new();
        private const double InclusiveThreshold = 0.999999;

        public T GetRandomNumber<T>(T? min = null, T? max = null) where T : struct, IComparable<T>
        {
            try
            {
                var (dmin, dmax, sample) = GetCommonValues<T>(min, max);

                if (typeof(T) == typeof(int))
                {
                    int intMin = min.HasValue ? (int)(object)min.Value : 0;
                    int intMax = max.HasValue ? (int)(object)max.Value : 1000000;
                    int intResult = intMin + (int)Math.Floor(sample * ((long)intMax - intMin + 1));
                    return (T)(object)intResult;
                }
                else if (typeof(T) == typeof(decimal))
                {
                    if (dmax == 1 && sample > InclusiveThreshold)
                        return (T)(object)1m;
                    decimal result = (decimal)dmin + (decimal)sample * ((decimal)dmax - (decimal)dmin);
                    return (T)(object)result;
                }
                else if (typeof(T) == typeof(double))
                {
                    if (dmax == 1 && sample > InclusiveThreshold)
                        return (T)(object)1.0;
                    double result = dmin + sample * (dmax - dmin);
                    return (T)(object)result;
                }
                else if (typeof(T) == typeof(float))
                {
                    if (dmax == 1 && sample > InclusiveThreshold)
                        return (T)(object)1f;
                    float result = (float)(dmin + sample * (dmax - dmin));
                    return (T)(object)result;
                }
                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }

        private (double dmin, double dmax, double sample) GetCommonValues<T>(T? min, T? max) where T : struct, IComparable<T>
        {
            double sample = _random.NextDouble();
            double dmin, dmax;

            if (typeof(T) == typeof(int))
            {
                dmin = min.HasValue ? Convert.ToDouble((int)(object)min.Value) : 0;
                dmax = max.HasValue ? Convert.ToDouble((int)(object)max.Value) : 1000000;
            }
            else if (typeof(T) == typeof(decimal))
            {
                dmin = min.HasValue ? Convert.ToDouble((decimal)(object)min.Value) : 0;
                dmax = max.HasValue ? Convert.ToDouble((decimal)(object)max.Value) : 1;
            }
            else if (typeof(T) == typeof(double))
            {
                dmin = min.HasValue ? (double)(object)min.Value : 0;
                dmax = max.HasValue ? (double)(object)max.Value : 1;
            }
            else if (typeof(T) == typeof(float))
            {
                dmin = min.HasValue ? Convert.ToDouble((float)(object)min.Value) : 0;
                dmax = max.HasValue ? Convert.ToDouble((float)(object)max.Value) : 1;
            }
            else
            {
                dmin = 0;
                dmax = 1;
            }

            return (dmin, dmax, sample);
        }

        public decimal GetRandomDecimalInRange(decimal? min = 0, decimal? max = 1, int? decimals = 2)
        {
            int dec = (decimals.HasValue && decimals.Value >= 0) ? decimals.Value : 2;
            decimal minVal = min ?? 0;
            decimal maxVal = max ?? 1;
            double sample = _random.NextDouble();

            if (maxVal == decimal.MaxValue && sample > InclusiveThreshold)
                return maxVal;

            decimal randomValue = minVal + ((decimal)sample * (maxVal - minVal));
            return Math.Round(randomValue, dec);
        }

    }
}
