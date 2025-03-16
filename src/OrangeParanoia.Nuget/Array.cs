using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia
{
    public class Array(IArrayService arrayService)
    {
        public T GetRandomValue<T>(T[] items)
        {
            return arrayService.GetRandomValue(items);
        }
    }
}
