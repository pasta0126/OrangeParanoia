namespace OrangeParanoia.Services.Interfaces
{
    public interface IDateService
    {
        string GetFutureDate(string? mask = null);
        string GetPastDate(string? mask = null);
        string GetFutureTime(string? mask = null);
        string GetPastTime(string? mask = null);
        string GetFutureDateTime(string? mask = null);
        string GetPastDateTime(string? mask = null);
    }
}
