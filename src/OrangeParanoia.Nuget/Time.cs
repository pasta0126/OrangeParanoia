using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia
{
    public class Time(IDateService dateService)
    {
        public string Random()
        {
            return dateService.GetRandomTime();
        }
    }
}
