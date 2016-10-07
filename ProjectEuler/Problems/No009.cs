using System;
using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Special Pythagorean triplet")]
    [Description(@"A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

a2 + b2 = c2
For example, 32 + 42 = 9 + 16 = 25 = 52.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.")]
    [Answer(31875000)]
    public class No009
    {
        public long Run(int n = 1000)
        {
            // a ^ 2 + b ^ 2 = c ^ 2
            // → a + b > c

            // a + b > c
            // a + b + c = n
            // → a + b > n / 2
            // → c < n / 2

            // c < n / 2
            // a < b < c
            // → a < n / 2
            // → b < n / 2

            // a < b
            // a + b > n / 2
            // → b > n / 4

            int a = 0, b = 0, c = 0;
            for (a = 2; a < n / 2; a++)
            {
                for (b = n / 4; b < n / 2; b++)
                {
                    if (a + b > n / 2)
                    {
                        c = n - a - b;

                        if (c > b)
                        {
                            if (c * c == a * a + b * b)
                            {
                                return a * b * c;
                            }
                        }
                    }
                }
            }

            throw new Exception("Could not find solution");
        }
    }
}
