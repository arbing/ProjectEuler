using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("10001st prime")]
    [Description(@"By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10 001st prime number?")]
    [Answer(104743)]
    public class No007
    {
        public long Run(long n = 10001)
        {
            var primes = new List<long>() { 2 };

            for (var i = 3L; i < long.MaxValue; i += 2)
            {
                CheckAndAddPrime(i, primes);

                if (primes.Count == n)
                {
                    break;
                }
            }

            return primes[primes.Count - 1];
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
