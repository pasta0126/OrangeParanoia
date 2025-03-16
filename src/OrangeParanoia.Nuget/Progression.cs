using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia
{
    public class Progression(IProgressionService progressionService)
    {
        public string Fibonacci(int n)
        {
            return progressionService.GetFibonacci(n);
        }

        public string Jacobsthal(int n)
        {
            return progressionService.GetJacobsthal(n);
        }

        public string Pell(int n)
        {
            return progressionService.GetPell(n);
        }

        public string HofstadterQ(int n)
        {
            return progressionService.GetHofstadterQ(n);
        }

        public double LogisticMap(int n)
        {
            return progressionService.GetLogisticMap(n);
        }

        public string Exotic(int n)
        {
            return progressionService.GetExotic(n);
        }

        public string Lucas(int n)
        {
            return progressionService.GetLucas(n);
        }
    }
}
