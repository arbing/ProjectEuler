using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Summation of primes")]
    [Description(@"The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million.")]
    [Answer(142913828922)]
    public class No010
    {
        public long Run(long n = 2 * 1000 * 1000)
        {
            var primes = GetPrimes(n);

            return primes.Sum();
        }

        public static List<long> GetPrimes(long max)
        {
            var primes = new List<long>() { 2 };

            for (var i = 3; i < max; i += 2)
            {
                CheckAndAddPrime(i, primes);
            }

            return primes;
        }

        public static bool CheckAndAddPrime(long n, List<long> primes)
        {
            var max = (long)Math.Sqrt(n);

            foreach (var prime in primes)
            {
                if (n % prime == 0)
                {
                    return false;
                }

                if (prime > max)
                {
                    break;
                }
            }

            primes.Add(n);
            return true;
        }
    }
}
