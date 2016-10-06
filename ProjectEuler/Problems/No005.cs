using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Smallest multiple")]
    [Description(@"2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?")]
    [Answer(232792560)]
    public class No005
    {
        public long Run(long number = 20)
        {
            var factors = new List<long>();

            var primes = GetPrimes(number);
            foreach (var prime in primes)
            {
                factors.Add(GetMaxPower(prime, number));
            }

            return factors.Aggregate(1L, (total, next) => total * next);
        }

        public static List<long> GetPrimes(long max)
        {
            var primes = new List<long>() { 2 };

            for (var i = 3; i < max; i += 2)
            {
                CheckAndAddPrime(i, primes);
            }

            return primes.ToList();
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

        public static long GetMaxPower(long prime, long max)
        {
            for (int i = 1; i < max; i++)
            {
                if (Math.Pow(prime, i + 1) > max)
                {
                    return (long)Math.Pow(prime, i);
                }
            }
            return prime;
        }
    }
}
