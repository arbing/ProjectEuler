using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Digit cancelling fractions")]
    [Description(@"The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.

We shall consider fractions like, 30/50 = 3/5, to be trivial examples.

There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.

If the product of these four fractions is given in its lowest common terms, find the value of the denominator.")]
    [Answer(100)]
    public class No033
    {
        public long Run()
        {
            var fractions = new List<int[]>();

            for (int n = 10; n < 100; n++)
            {
                for (int d = n + 1; d < 100; d++)
                {
                    if (n % 10 == d / 10)
                    {
                        var cn = n / 10;
                        var cd = d % 10;

                        if (n * cd == d * cn)
                        {
                            fractions.Add(new[] { n, d });
                        }
                    }
                }
            }

            var product = new[] { 1, 1 };
            for (int i = 0; i < fractions.Count; i++)
            {
                Simplify(ref fractions[i][0], ref fractions[i][1]);
                product[0] = product[0] * fractions[i][0];
                product[1] = product[1] * fractions[i][1];
            }

            Simplify(ref product[0], ref product[1]);

            return product[1];
        }

        private void Simplify(ref int n, ref int d)
        {
            var prime = 2;
            while (true)
            {
                if (n % prime == 0 && d % prime == 0)
                {
                    n = n / prime;
                    d = d / prime;

                    prime = 2;
                }
                else
                {
                    if (n < prime)
                    {
                        return;
                    }

                    while (true)
                    {
                        prime++;

                        if (IsPrime(prime))
                        {
                            break;
                        }
                    }
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
