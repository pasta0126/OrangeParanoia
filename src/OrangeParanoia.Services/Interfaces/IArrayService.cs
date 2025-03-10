namespace OrangeParanoia.Services.Interfaces
{
    public interface IArrayService
    {
        T GetRandomValue<T>(T[] items);
    }
}
