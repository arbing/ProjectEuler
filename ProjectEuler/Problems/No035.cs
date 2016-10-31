using System;
using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Circular primes")]
    [Description(@"The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.

There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.

How many circular primes are there below one million?")]
    [Answer(55)]
    public class No035
    {
        public long Run(int n = 1000 * 1000)
        {
            var cnt = 0;
            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i) && IsCircularPrime(i))
                {
                    cnt++;
                }
            }

            return cnt;
        }

        private bool IsCircularPrime(int n)
        {
            var str = n.ToString();
            var d = str.Length;

            if (d == 1)
            {
                return true;
            }

            for (int i = 1; i < d; i++)
            {
                var newn = int.Parse(str.Substring(i) + str.Substring(0, i));

                if (!IsPrime(newn))
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
