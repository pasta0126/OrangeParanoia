using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Services
{
    public class NumberService : INumberService
    {
        private static readonly Random _random = new();

        public T GetRandomNumber<T>(T? min = null, T? max = null) where T : struct, IComparable<T>
        {
            if (typeof(T) == typeof(int))
            {
                int minValue = min.HasValue ? (int)(object)min.Value : int.MinValue;
                int maxValue = max.HasValue ? (int)(object)max.Value : int.MaxValue;
                int result = _random.Next(minValue, maxValue);
                return (T)(object)result;
            }

            if (typeof(T) == typeof(decimal))
            {
                decimal minValue = min.HasValue ? (decimal)(object)min.Value : decimal.MinValue;
                decimal maxValue = max.HasValue ? (decimal)(object)max.Value : decimal.MaxValue;
                double sample = _random.NextDouble();
                decimal result = minValue + (decimal)sample * (maxValue - minValue);
                return (T)(object)result;
            }

            if (typeof(T) == typeof(double))
            {
                double minValue = min.HasValue ? (double)(object)min.Value : double.MinValue;
                double maxValue = max.HasValue ? (double)(object)max.Value : double.MaxValue;
                double result = minValue + _random.NextDouble() * (maxValue - minValue);
                return (T)(object)result;
            }

            if (typeof(T) == typeof(float))
            {
                float minValue = min.HasValue ? (float)(object)min.Value : float.MinValue;
                float maxValue = max.HasValue ? (float)(object)max.Value : float.MaxValue;
                float result = minValue + (float)_random.NextDouble() * (maxValue - minValue);
                return (T)(object)result;
            }

            return default;
        }

        public decimal GetRandomDecimalInRange(decimal min = 0, decimal max = 1, int decimals = 2)
        {
            if (decimals < 0)
                decimals = 2;

            decimal randomValue = min + ((decimal)_random.NextDouble() * (max - min));

            return Math.Round(randomValue, decimals);
        }
    }
}
