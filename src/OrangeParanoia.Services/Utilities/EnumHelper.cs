namespace OrangeParanoia.Services.Utilities
{
    public static class EnumHelper<T> where T : Enum
    {
        private static readonly Random _random = new();

        public static T GetRandomValue()
        {
            T[] values = Enum.GetValues(typeof(T)).OfType<T>().ToArray();
            return values[_random.Next(values.Length)];
        }

        public static string IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            var enumNames = Enum.GetNames(typeof(T));

            foreach (var name in enumNames)
            {
                if (string.Equals(name, value, StringComparison.OrdinalIgnoreCase))
                {
                    return name;
                }
            }

            return null;
        }

        public static T FromString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            var validName = IsValid(value);

            if (validName == null)
            {
                throw new ArgumentException($"'{value}' no es un valor válido para el enum {typeof(T).Name}.", nameof(value));
            }

            return (T)Enum.Parse(typeof(T), validName, true);
        }
    }
}
