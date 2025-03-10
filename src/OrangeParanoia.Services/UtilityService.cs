using OrangeParanoia.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace OrangeParanoia.Services
{
    public class UtilityService : IUtilityService
    {
        public string GetHexColor(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "#000000";
            byte[] hashBytes = MD5.HashData(Encoding.UTF8.GetBytes(input));
            return $"#{hashBytes[0]:X2}{hashBytes[1]:X2}{hashBytes[2]:X2}";
        }

        public string GetHexColor2(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "#000000";
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(input));
            return $"#{hash[0]:X2}{hash[1]:X2}{hash[2]:X2}";
        }

        public string GetRgbColor(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "rgb(0, 0, 0)";
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(input));
            return $"rgb({hash[0]}, {hash[1]}, {hash[2]})";
        }

        public string GetRgbaColor(string input, double alpha = 1.0)
        {
            if (string.IsNullOrEmpty(input))
                return $"rgba(0, 0, 0, {alpha})";
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(input));
            return $"rgba({hash[0]}, {hash[1]}, {hash[2]}, {alpha})";
        }
    }
}
