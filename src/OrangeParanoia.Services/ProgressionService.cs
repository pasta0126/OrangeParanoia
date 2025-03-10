using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Services
{
    public class ProgressionService : IProgressionService
    {
        private readonly Dictionary<int, int> _cacheFibonacci = [];
        private readonly Dictionary<int, int> _cacheJacobsthal = [];
        private readonly Dictionary<int, int> _cacheLucas = [];
        private readonly Dictionary<int, int> _cachePell = [];
        private readonly Dictionary<int, int> _cacheHofstadterQ = [];
        private readonly Dictionary<int, int> _cacheExotic = [];

        public int GetFibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            if (_cacheFibonacci.TryGetValue(n, out int value))
            {
                return value;
            }

            int result = GetFibonacci(n - 1) + GetFibonacci(n - 2);

            _cacheFibonacci[n] = result;

            return result;
        }

        public int GetJacobsthal(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            if (_cacheJacobsthal.TryGetValue(n, out int value))
            {
                return value;
            }

            int result = GetJacobsthal(n - 1) + 2 * GetJacobsthal(n - 2);

            _cacheJacobsthal[n] = result;

            return result;
        }

        public int GetLucas(int n)
        {
            if (n == 0) return 2;
            if (n == 1) return 1;
            if (_cacheLucas.TryGetValue(n, out int value))
            {
                return value;
            }

            int result = GetLucas(n - 1) + GetLucas(n - 2);

            _cacheLucas[n] = result;

            return result;
        }

        public int GetPell(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (_cachePell.TryGetValue(n, out int value))
            {
                return value;
            }

            int result = 2 * GetPell(n - 1) + GetPell(n - 2);

            _cachePell[n] = result;

            return result;
        }

        public int GetHofstadterQ(int n)
        {
            if (n <= 0) return 0; // throw new ArgumentException("Hofstadter Q está definida para n >= 1");
            if (n == 1 || n == 2) return 1;
            if (_cacheHofstadterQ.TryGetValue(n, out int value))
            {
                return value;
            }

            int result = GetHofstadterQ(n - GetHofstadterQ(n - 1)) + GetHofstadterQ(n - GetHofstadterQ(n - 2));

            _cacheHofstadterQ[n] = result;

            return result;
        }

        public double GetLogisticMap(int n)
        {
            double r = 4.0;
            double x0 = 0.2;
            double x = x0;

            for (int i = 0; i < n; i++)
            {
                x = r * x * (1 - x);
            }

            return x;
        }

        public int GetExotic(int n)
        {
            if (n == 0) return 1;
            if (n == 1) return 1;
            if (_cacheExotic.TryGetValue(n, out int cachedValue))
            {
                return cachedValue;
            }

            int groupSize = 3;
            int group = n / groupSize;
            int sign = (group % 2 == 0) ? 1 : -1;

            int result = sign * (Math.Abs(GetExotic(n - 1)) + Math.Abs(GetExotic(n - 2)));
            _cacheExotic[n] = result;
            return result;
        }
    }
}
