using OrangeParanoia.Services.Interfaces;
using System.Numerics;

namespace OrangeParanoia.Services
{
    public class ProgressionService : IProgressionService
    {
        private readonly Dictionary<int, BigInteger> _cacheFibonacci = new();
        private readonly Dictionary<int, BigInteger> _cacheJacobsthal = new();
        private readonly Dictionary<int, BigInteger> _cacheLucas = new();
        private readonly Dictionary<int, BigInteger> _cachePell = new();
        private readonly Dictionary<int, BigInteger> _cacheHofstadterQ = new();
        private readonly Dictionary<int, BigInteger> _cacheExotic = new();

        public string GetFibonacci(int n)
        {
            BigInteger result = GetFibonacciBig(n);
            return result.ToString();
        }

        private BigInteger GetFibonacciBig(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            if (_cacheFibonacci.TryGetValue(n, out BigInteger value))
                return value;
            BigInteger result = GetFibonacciBig(n - 1) + GetFibonacciBig(n - 2);
            _cacheFibonacci[n] = result;
            return result;
        }

        public string GetJacobsthal(int n)
        {
            BigInteger result = GetJacobsthalBig(n);
            return result.ToString();
        }

        private BigInteger GetJacobsthalBig(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            if (_cacheJacobsthal.TryGetValue(n, out BigInteger value))
                return value;
            BigInteger result = GetJacobsthalBig(n - 1) + 2 * GetJacobsthalBig(n - 2);
            _cacheJacobsthal[n] = result;
            return result;
        }

        public string GetLucas(int n)
        {
            BigInteger result = GetLucasBig(n);
            return result.ToString();
        }

        private BigInteger GetLucasBig(int n)
        {
            if (n == 0) return 2;
            if (n == 1) return 1;
            if (_cacheLucas.TryGetValue(n, out BigInteger value))
                return value;
            BigInteger result = GetLucasBig(n - 1) + GetLucasBig(n - 2);
            _cacheLucas[n] = result;
            return result;
        }

        public string GetPell(int n)
        {
            BigInteger result = GetPellBig(n);
            return result.ToString();
        }

        private BigInteger GetPellBig(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (_cachePell.TryGetValue(n, out BigInteger value))
                return value;
            BigInteger result = 2 * GetPellBig(n - 1) + GetPellBig(n - 2);
            _cachePell[n] = result;
            return result;
        }

        public string GetHofstadterQ(int n)
        {
            BigInteger result = GetHofstadterQBig(n);
            return result.ToString();
        }

        private BigInteger GetHofstadterQBig(int n)
        {
            if (n <= 0) return 0;
            if (n == 1 || n == 2) return 1;
            if (_cacheHofstadterQ.TryGetValue(n, out BigInteger value))
                return value;
            // Nota: la definición original de Hofstadter Q utiliza recursión en base a índices
            int index1 = n - (int)GetHofstadterQBig(n - 1);
            int index2 = n - (int)GetHofstadterQBig(n - 2);
            BigInteger result = GetHofstadterQBig(index1) + GetHofstadterQBig(index2);
            _cacheHofstadterQ[n] = result;
            return result;
        }

        public double GetLogisticMap(int n)
        {
            double r = 4.0;
            double x = 0.2;
            for (int i = 0; i < n; i++)
            {
                x = r * x * (1 - x);
            }
            return x;
        }

        public string GetExotic(int n)
        {
            BigInteger result = GetExoticBig(n);
            return result.ToString();
        }

        private BigInteger GetExoticBig(int n)
        {
            if (n == 0) return 1;
            if (n == 1) return 1;
            if (_cacheExotic.TryGetValue(n, out BigInteger cachedValue))
                return cachedValue;
            int groupSize = 3;
            int group = n / groupSize;
            int sign = (group % 2 == 0) ? 1 : -1;
            BigInteger result = sign * (BigInteger.Abs(GetExoticBig(n - 1)) + BigInteger.Abs(GetExoticBig(n - 2)));
            _cacheExotic[n] = result;
            return result;
        }
    }
}
