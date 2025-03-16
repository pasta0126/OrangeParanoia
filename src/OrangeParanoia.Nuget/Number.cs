using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia
{
    public class Number(INumberService numberService)
    {
        public T Random<T>(T? min = null, T? max = null) where T : struct, IComparable<T>
        {
            return numberService.GetRandomNumber(min, max);
        }

        public decimal RandomDecimalInRange(decimal? min = 0, decimal? max = 1, int? decimals = 2)
        {
            return numberService.GetRandomDecimalInRange(min, max, decimals);
        }
    }
}
