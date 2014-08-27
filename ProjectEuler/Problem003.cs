using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem003
    {
        public static long Run(long number = 600851475143)
        {
            var max = (long)Math.Sqrt(number) + 1;

            var primes = GetPrimes(max);

            var i = primes.Count - 1;

            while (true)
            {
                if (number % primes[i] == 0)
                {
                    break;
                }

                i--;
            }

            return primes[i];
        }

        public static List<long> GetPrimes(long number)
        {
            var primes = new List<long>();

            for (var i = 1; i < number; i++)
            {
                if (IsPrime(i, primes))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        public static bool IsPrime(long number, List<long> primes)
        {
            if (number < 2)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            var max = (long)Math.Sqrt(number);

            foreach (var n in primes)
            {
                if (number % n == 0)
                {
                    return false;
                }

                if (n > max)
                {
                    break;
                }
            }

            return true;
        }
    }
}
