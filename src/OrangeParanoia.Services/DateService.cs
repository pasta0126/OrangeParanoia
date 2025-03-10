using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Services
{
    public class DateService : IDateService
    {
        private static readonly Random _random = new();
        private const string DefaultDateFormat = "yyyy-MM-dd";
        private const string DefaultTimeFormat = "HH:mm:ss";
        private const string DefaultDateTimeFormat = "u";

        public string GetFutureDate(string? mask = null)
        {
            try
            {
                mask ??= DefaultDateFormat;
                DateOnly futureDate = DateOnly.FromDateTime(DateTime.Now.AddDays(_random.Next(1, 366)));
                return futureDate.ToString(mask);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string GetPastDate(string? mask = null)
        {
            try
            {
                mask ??= DefaultDateFormat;
                DateOnly pastDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-_random.Next(1, 366)));
                return pastDate.ToString(mask);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string GetFutureTime(string? mask = null)
        {
            try
            {
                mask ??= DefaultTimeFormat;
                TimeOnly futureTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(_random.Next(1, 25)));
                return futureTime.ToString(mask);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string GetPastTime(string? mask = null)
        {
            try
            {
                mask ??= DefaultTimeFormat;
                TimeOnly pastTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(-_random.Next(1, 25)));
                return pastTime.ToString(mask);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string GetFutureDateTime(string? mask = null)
        {
            try
            {
                mask ??= DefaultDateTimeFormat;
                DateTime futureDateTime = DateTime.Now.AddDays(_random.Next(1, 366)).AddHours(_random.Next(1, 25));
                return futureDateTime.ToString(mask);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string GetPastDateTime(string? mask = null)
        {
            try
            {
                mask ??= DefaultDateTimeFormat;
                DateTime pastDateTime = DateTime.Now.AddDays(-_random.Next(1, 366)).AddHours(-_random.Next(1, 25));
                return pastDateTime.ToString(mask);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
