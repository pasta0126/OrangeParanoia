namespace OrangeParanoia.Services.Interfaces
{
    public interface IUtilityService
    {
        string GetHexColor(string input);
        string GetHexColor2(string input);
        string GetRgbColor(string input);
        string GetRgbaColor(string input, double alpha = 1.0);
    }
}
