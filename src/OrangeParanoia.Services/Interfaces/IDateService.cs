namespace OrangeParanoia.Services.Interfaces
{
    public interface IDateService
    {
        string GetFutureDate(string mask = null);
        string GetPastDate(string mask = null);
        string GetRandomDateByAgeRange(int minAge = 18, int? maxAge = 120, string mask = null);
        string GetRandomTime(string mask = null);
        string GetFutureDateTime(string mask = null);
        string GetPastDateTime(string mask = null);
    }
}
