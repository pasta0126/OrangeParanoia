namespace OrangeParanoia.Services.Interfaces
{
    public interface INumberService
    {
        T GetRandomNumber<T>(T? min = null, T? max = null) where T : struct, IComparable<T>;
        decimal GetRandomDecimalInRange(decimal? min = 0, decimal? max = 1, int? decimals = 2);
    }
}
