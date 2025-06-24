using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Services
{
    public class IdentityService(IArrayService arrayService) : IIdentityService
    {
        public IdentityData GenerateIdentity()
        {
            return new();
        }
    }

    public class IdentityData
    {
        public string NobleTitle { get; private set; }
        public string Title { get; private set; }
        public string Name { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Gender { get; private set; }
        public string FullName => string.Join(" ", new[] { NobleTitle, Title, Name, MiddleName, LastName }
            .Where(s => !string.IsNullOrEmpty(s)));
        public DateOnly Birthday { get; private set; }
        public int Age => CalculateAge(Birthday);
        private static int CalculateAge(DateOnly birthday)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - birthday.Year;
            if (birthday > today.AddYears(-age)) age--;
            return age;
        }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string Company { get; private set; }

        public IdentityData()
        {

        }
    }

    public enum Sex
    {
        Male,
        Female,
    }

    public enum GenderIdentity
    {
        Cisgender = 90,     // género asignado al nacer coincide con su identidad de género
        Transgender = 7,    // persona asignada que ha cambiado su género
        NonBinary = 6,      // identidad fuera de las categorías exclusivamente masculina o femenina
        Queer = 5,          // identidad que rechaza las normas tradicionales de género
        Agender = 4,        // ausencia de género o falta de identidad de género
        Bigender = 3,       // persona que alterna entre dos géneros o se identifica con ambos
        Genderfluid = 2,    // identidad que cambia o ﬂuctúa entre distintos géneros
        Intergender = 1,    // identidad entre los géneros masculino y femenino
    }
}
