using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia
{
    public class Date(IDateService dateService)
    {
        public string PastDate()
        {
            return dateService.GetPastDate();
        }

        public string FutureDate()
        {
            return dateService.GetFutureDate();
        }
    }
}
