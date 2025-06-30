using OrangeParanoia.Services.Interfaces;
using OrangeParanoia.Services.Utilities;

namespace OrangeParanoia.Services
{
    public class IdentityService(IDateService dateService) : IIdentityService
    {
        public IdentityData GenerateHumanIdentity(
            bool WithNobleTitle = false,
            bool WithTitle = false,
            bool WithMiddleName = false
            )
        {
            var data = new IdentityData();

            data.NobleTitle = WithNobleTitle ? ListHelper.GetRandomValue(data.NobleTitleData) : null;
            data.Title = WithTitle ? ListHelper.GetRandomValue(data.TitleData) : null;

            var sexWeights = new Dictionary<string, int>
            {
                ["Male"] = 45,
                ["Female"] = 45,
                ["Other"] = 10
            };

            var sex = ListHelper.GetRandomWeightedValue(sexWeights);
            data.Gender = sex;

            if (sex == "Male")
            {
                data.Name = ListHelper.GetRandomValue(data.ManNameData);
            }
            else if (sex == "Female")
            {
                data.Name = ListHelper.GetRandomValue(data.FemaleNameData);
            }
            else
            {
                var combinedNames = new List<string>(data.ManNameData);
                combinedNames.AddRange(data.FemaleNameData);
                data.Name = ListHelper.GetRandomValue(combinedNames);
                data.Gender = ListHelper.GetRandomValue(data.GenderData);
            }

            data.MiddleName = WithTitle ? ListHelper.GetRandomValue(data.MiddleNameData) : null;
            data.LastName = ListHelper.GetRandomValue(data.LastNameData);
            data.Birthday = DateOnly.Parse(dateService.GetPastDate());
            data.City = ListHelper.GetRandomValue(data.CityData);
            data.Company = ListHelper.GetRandomValue(data.CompanyData);
            data.Department = ListHelper.GetRandomValue(data.DepartmentData);

            return data;
        }
    }

    public class IdentityData
    {
        public string NobleTitle { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string FullName => string.Join(" ", new[] { NobleTitle, Title, Name, MiddleName, LastName }
            .Where(s => !string.IsNullOrEmpty(s)));
        public DateOnly Birthday { get; set; }
        public int Age => CalculateAge(Birthday);
        public string City { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }

        public List<string> CompanyData = [
            "AstraNova Holdings",
            "Horizonte Azul Energía",
            "QuantumLeap Solutions",
            "Grupo Infinito",
            "Terranova Biotech",
            "NexaCorp Global",
            "Solstice Innovations",
            "Altura Financial Services",
            "LumenTech Systems",
            "EcoVita Resources",
            "Vortex Dynamics",
            "Celeste Robotics",
            "Orbis Marketing",
            "FusionWave Media",
            "Axis Constructores",
            "Sentinel Seguridad",
            "Vertex Consultores",
            "Aurora Pharma",
            "Pangea Shipping",
            "NovaPlex Networks",
            "TerraPrime Market",
            "OptiMax Logistics",
            "Zenith Apparel",
            "BluePeak Ventures",
            "QuantumGrid Energy",
            "Prisma Arquitectura",
            "Omnia Salud",
            "Sigma Aeroespacial",
            "MetroLink Transit",
            "Elevate Real Estate",
            "CypherTech Cybersecurity",
            "BioHorizon Labs",
            "SkyBridge Airlines",
            "EcoSphere Agricultura",
            "Lumina Entertainment",
            "AlphaWave Inteligencia Artificial",
            "GlobalVista Analytics",
            "Nexus Education",
            "TransWorld Freight",
            "Solara Resort Management",
            "Titan Manufacturing",
            "VitalCore Nutrición",
            "Emerald Financial Group",
            "NeoFusion Ingeniería",
            "EcoSense Urban Planning",
            "Helix Digital",
            "Meridian Travel",
            "UrbanPulse Inmobiliaria",
            "Hyperion Automotriz",
            "AcquaPure Sistemas"
        ];

        public List<string> DepartmentData = [
            "Human Resources",
            "Finance",
            "Marketing",
            "Sales",
            "Research & Development",
            "Information Technology",
            "Operations",
            "Legal",
            "Logistics",
            "Customer Service",
            "Quality Control",
            "Corporate Communications",
            "Strategy & Planning",
            "Corporate Social Responsibility",
            "Occupational Health & Safety",
            "Internal Audit",
            "Public Relations",
            "Project Management",
        ];

        public List<string> CityData = [
            "London",
            "Paris",
            "Berlin",
            "Madrid",
            "Rome",
            "Amsterdam",
            "Vienna",
            "Lisbon",
            "Dublin",
            "Stockholm",
            "Tokyo",
            "Shanghai",
            "Beijing",
            "Mumbai",
            "Delhi",
            "Seoul",
            "Bangkok",
            "Singapore",
            "Hong Kong",
            "Jakarta",
            "Cairo",
            "Lagos",
            "Johannesburg",
            "Nairobi",
            "Casablanca",
            "Accra",
            "Addis Ababa",
            "Tunis",
            "Algiers",
            "Dakar",
            "New York",
            "Los Angeles",
            "Chicago",
            "Toronto",
            "Mexico City",
            "Houston",
            "Montreal",
            "Miami",
            "Vancouver",
            "San Francisco",
            "São Paulo",
            "Buenos Aires",
            "Rio de Janeiro",
            "Bogotá",
            "Lima",
            "Santiago",
            "Caracas",
            "Quito",
            "Montevideo",
            "Salvador",
            "Sydney",
            "Melbourne",
            "Auckland",
            "Brisbane",
            "Perth",
            "Wellington",
            "Suva",
            "Port Moresby",
            "Honolulu",
            "Christchurch",
            "Dubai",
            "Istanbul",
            "Riyadh",
            "Tel Aviv",
            "Doha",
            "Kuwait City",
            "Beirut",
            "Tehran",
            "Amman",
            "Muscat",
            "Moscow",
            "Astana",
            "Tashkent",
            "Almaty",
            "Bishkek",
            "Dushanbe",
            "Ashgabat",
            "Yerevan",
            "Baku",
            "Tbilisi",
            "Barcelona",
            "Frankfurt",
            "Munich",
            "Warsaw",
            "Budapest",
            "Prague",
            "Copenhagen",
            "Helsinki",
            "Oslo",
            "Zurich",
            "Seattle",
            "Boston",
            "Atlanta",
            "Dallas",
            "Philadelphia",
            "Phoenix",
            "Manchester",
            "Lyon",
            "Rotterdam",
            "Hamburg",
        ];

        public List<string> TitleData =
        [
            "Mr",
            "Mrs",
            "Miss",
            "Ms",
            "Dr",
            "Prof",
        ];

        public List<string> NobleTitleData = [
            "Duke",
            "Duchess",
            "Count",
            "Countess",
            "Baron",
            "Baroness",
            "Lord",
            "Lady",
            "Sir",
            "Dame"
        ];

        public List<string> RaceData = [
            "Human",
            "Extraterrestrial",
            "Android",
        ];

        public List<string> FemaleNameData = [
            "Marie",
            "Chiara",
            "Olivia",
            "Anna",
            "Sofia",
            "Inis",
            "Elise",
            "Maud",
            "Aoife",
            "Lea",
            "Anastasia",
            "Zofia",
            "Eszter",
            "Ekaterina",
            "Mihaela",
            "Kateryna",
            "Katarena",
            "Egle",
            "Elina",
            "Milica",
            "Emily",
            "Charlotte",
            "Ximena",
            "Harper",
            "Sophia",
            "Mia",
            "Ava",
            "Zoe",
            "Isabella",
            "Lily",
            "Valentina",
            "Camila",
            "Fernanda",
            "Carolina",
            "Ana",
            "Natalia",
            "Laura",
            "Maria",
            "Patricia",
            "Gabriela",
            "Fatima",
            "Sara",
            "Zahra",
            "Elif",
            "Maya",
            "Noor",
            "Aisha",
            "Lina",
            "Dima",
            "Nouf",
            "Ama",
            "Thandi",
            "Amina",
            "Chioma",
            "Lulit",
            "Zuri",
            "Adjoa",
            "Nomvula",
            "Nia",
            "Zawadi",
            "Asma",
            "Samira",
            "Leila",
            "Khadija",
            "Salma",
            "Mona",
            "Nadia",
            "Rachida",
            "Yusra",
            "Amel",
            "Priya",
            "Nida",
            "Sita",
            "Rahima",
            "Anjali",
            "Deepika",
            "Kavya",
            "Nirmala",
            "Chamari",
            "Shanti",
            "Li",
            "Sakura",
            "Jiwoo",
            "Thúy",
            "Ayu",
            "Haruka",
            "Mei",
            "Yuna",
            "Linh",
            "Putri",
            "Pania",
            "Aroha",
            "Fia",
            "Mele",
            "Anahera",
            "Marama",
            "Litia",
            "Ema",
            "Fetu",
            "Malia"
        ];

        public List<string> ManNameData = [
            "Alexandre",
            "Giovanni",
            "Oliver",
            "Hans",
            "Miguel",
            "Lucas",
            "Émile",
            "Lars",
            "Seán",
            "Matthias",
            "Aleksandr",
            "Piotr",
            "Istvan",
            "Dimitar",
            "Ion",
            "Nikita",
            "Marek",
            "Arunas",
            "Kristaps",
            "Vlado",
            "Michael",
            "James",
            "Jose",
            "William",
            "Liam",
            "Juan",
            "Robert",
            "Ethan",
            "Alejandro",
            "David",
            "Matías",
            "Sebastian",
            "Andres",
            "Rodrigo",
            "Carlos",
            "Daniel",
            "Gabriel",
            "Esteban",
            "Jorge",
            "Mohammad",
            "Ahmed",
            "Ali",
            "Yusuf",
            "Mostafa",
            "Omar",
            "Hassan",
            "Khalid",
            "Ibrahim",
            "Nabil",
            "Kwame",
            "Thabo",
            "Chinedu",
            "Abebe",
            "Juma",
            "Oluwaseun",
            "Kofi",
            "Amadou",
            "Zola",
            "Youssef",
            "Mahdi",
            "Anwar",
            "Karim",
            "Said",
            "Hamid",
            "Samir",
            "Nadir",
            "Rachid",
            "Rahul",
            "Muhammad",
            "Sanjay",
            "Ramesh",
            "Shafiq",
            "Amir",
            "Pradeep",
            "Arun",
            "Sajid",
            "Wei",
            "Takumi",
            "Nguyen",
            "Achmad",
            "Satoshi",
            "Chen",
            "Jiro",
            "An",
            "Than",
            "Jack",
            "Kaha",
            "Tui",
            "Mani",
            "Tevita",
            "George",
            "Patrick",
            "Jone",
            "Eroni"
        ];

        public List<string> MiddleNameData = [
            "Alexander",
            "Marie",
            "James",
            "Elizabeth",
            "Michael",
            "Anne",
            "John",
            "Grace",
            "William",
            "Rose",
            "David",
            "Jane",
            "Thomas",
            "Louise",
            "Charles",
            "Claire"
        ];

        public List<string> LastNameData = [
            "Smith",
            "Johnson",
            "Williams",
            "Brown",
            "Jones",
            "Garcia",
            "Miller",
            "Davis",
            "Rodriguez",
            "Martinez",
            "Hernandez",
            "Lopez",
            "Gonzalez",
            "Wilson",
            "Anderson"
        ];

        public List<string> GenderData = [
            "Male",
            "Female",
            "NonBinary",
            "NonGender",
            "Fluid",
            "Hermaphrodite",
            "Agender",
            "Bigender",
            "Demigender",
            "Androgyne",
        ];

        private static int CalculateAge(DateOnly birthday)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - birthday.Year;
            if (birthday > today.AddYears(-age)) age--;
            return age;
        }
    }
}
