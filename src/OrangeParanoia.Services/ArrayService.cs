using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Services
{
    public class ArrayService : IArrayService
    {
        private static readonly Random _random = new();

        public T GetRandomValue<T>(T[] items)
        {
            if (items == null || items.Length == 0)
                return default!;
            return items[_random.Next(items.Length)];
        }
    }
}
