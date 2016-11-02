using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Truncatable primes")]
    [Description(@"The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.")]
    [Answer(748317)]
    public class No037
    {
        public long Run(long n = 11)
        {
            var primes = new List<long>();
            for (int i = 11; ; i += 2)
            {
                if (IsPrime(i) && IsTruncatable(i))
                {
                    primes.Add(i);
                }

                if (primes.Count == n)
                {
                    break;
                }
            }

            return primes.Sum();
        }

        public bool IsTruncatable(long n)
        {
            var r = n;
            while (r > 10)
            {
                r = r % (long)Math.Pow(10, r.ToString().Length - 1);
                if (!IsPrime(r))
                {
                    return false;
                }
            }

            var l = n;
            while (l > 10)
            {
                l = l / 10;
                if (!IsPrime(l))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsPrime(long n)
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
