using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia
{
    public class DateTime(IDateService dateService)
    {
        public string FutureDateTime()
        {
            return dateService.GetFutureDateTime();
        }

        public string PastDateTime()
        {
            return dateService.GetPastDateTime();
        }
    }
}
