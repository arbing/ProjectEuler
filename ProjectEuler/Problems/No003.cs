using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Largest prime factor")]
    [Description(@"The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?")]
    [Answer(6857)]
    public class No003
    {
        public long Run(long n = 600851475143)
        {
            var max = (long)Math.Sqrt(n) + 1;

            var primes = GetPrimes(max);

            var i = primes.Count - 1;

            while (true)
            {
                if (n % primes[i] == 0)
                {
                    break;
                }

                i--;
            }

            return primes[i];
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
