using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Digit fifth powers")]
    [Description(@"Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

1634 = 14 + 64 + 34 + 44
8208 = 84 + 24 + 04 + 84
9474 = 94 + 44 + 74 + 44
As 1 = 14 is not a sum it is not included.

The sum of these numbers is 1634 + 8208 + 9474 = 19316.

Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.")]
    [Answer(443839)]
    public class No030
    {
        public long Run(int n = 5)
        {
            var numbers = new List<int>();
            for (int i = 2; i < (int)Math.Pow(10, n + 1); i++)
            {
                if (i == SumPowers(i, n))
                {
                    numbers.Add(i);
                }
            }

            return numbers.Sum();
        }

        private int SumPowers(int n, int p)
        {
            return n.ToString().ToArray().Select(i => (int)Math.Pow(int.Parse(i.ToString()), p)).Sum();
        }
    }
}
