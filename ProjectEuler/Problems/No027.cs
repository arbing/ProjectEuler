using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Quadratic primes")]
    [Description(@"Euler discovered the remarkable quadratic formula:

n2+n+41n2+n+41
It turns out that the formula will produce 40 primes for the consecutive integer values 0≤n≤390≤n≤39. However, when n=40,402+40+41=40(40+1)+41n=40,402+40+41=40(40+1)+41 is divisible by 41, and certainly when n=41,412+41+41n=41,412+41+41 is clearly divisible by 41.

The incredible formula n2−79n+1601n2−79n+1601 was discovered, which produces 80 primes for the consecutive values 0≤n≤790≤n≤79. The product of the coefficients, −79 and 1601, is −126479.

Considering quadratics of the form:

n2+an+bn2+an+b, where |a|<1000|a|<1000 and |b|≤1000|b|≤1000

where |n||n| is the modulus/absolute value of nn
e.g. |11|=11|11|=11 and |−4|=4|−4|=4
Find the product of the coefficients, aa and bb, for the quadratic expression that produces the maximum number of primes for consecutive values of nn, starting with n=0n=0.")]
    [Answer(-59231)]
    public class No027
    {
        public long Run(long n = 1000)
        {
            var primes = new List<int>();

            for (var i = 2; i < n; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            var max = 0;
            int a = 0, b = 0;
            foreach (var prime in primes)
            {
                for (int i = 1; i < n; i += 2)
                {
                    var cnt = CountPrimes(i, prime);
                    if (cnt > max)
                    {
                        max = cnt;
                        a = i;
                        b = prime;
                    }

                    cnt = CountPrimes(-i, prime);
                    if (cnt > max)
                    {
                        max = cnt;
                        a = -i;
                        b = prime;
                    }
                }
            }

            return a * b;
        }

        public int CountPrimes(int a, int b)
        {
            for (int i = 0; ; i++)
            {
                var res = i * i + a * i + b;
                if (!IsPrime(res))
                {
                    return i;
                }
            }
        }

        public bool IsPrime(long n)
        {
            if (n < 1)
            {
                return false;
            }
            else if (n == 1)
            {
                return false;
            }
            else if (n < 4)
            {
                return true;
            }
            else if (n % 2 == 0)
            {
                return false;
            }
            else if (n < 9)
            {
                return true;
            }
            else if (n % 3 == 0)
            {
                return false;
            }
            else
            {
                var max = (long)Math.Sqrt(n);
                var f = 5L;
                while (f <= max)
                {
                    if (n % f == 0)
                    {
                        return false;
                    }

                    if (n % (f + 2) == 0)
                    {
                        return false;
                    }

                    f += 6;
                }
            }

            return true;
        }
    }
}
