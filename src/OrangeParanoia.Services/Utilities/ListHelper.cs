namespace OrangeParanoia.Services.Utilities
{
    public static class ListHelper
    {
        private static readonly Random _random = new();

        public static T GetRandomValue<T>(IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return default;
            }

            return list[_random.Next(list.Count)];
        }

        public static T GetRandomWeightedValue<T>(IDictionary<T, int> weights)
        {
            if (weights == null || weights.Count == 0)
            {
                return default;
            }

            long totalWeight = 0;
            foreach (var weight in weights.Values)
            {
                totalWeight += weight;
            }

            if (totalWeight <= 0)
            {
                return default;
            }

            var target = _random.NextInt64(totalWeight);
            long cumulative = 0;

            foreach (var kvp in weights)
            {
                cumulative += kvp.Value;
                if (target < cumulative)
                {
                    return kvp.Key;
                }
            }

            return default;
        }

    }
}
