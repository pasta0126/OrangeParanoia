using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia
{
    public class Utility(IUtilityService utilityService)
    {
        public string HexColor(string input)
        {
            return utilityService.GetHexColor(input);
        }

        public string HexColor2(string input)
        {
            return utilityService.GetHexColor2(input);
        }

        public string Rgb(string input)
        {
            return utilityService.GetRgbColor(input);
        }

        public string Rgba(string input, double alpha = 1.0)
        {
            return utilityService.GetRgbaColor(input, alpha);
        }
    }
}
