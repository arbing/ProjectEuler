using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Digit factorials")]
    [Description(@"145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

Find the sum of all numbers which are equal to the sum of the factorial of their digits.

Note: as 1! = 1 and 2! = 2 are not sums they are not included.")]
    [Answer(40730)]
    public class No034
    {
        public long Run()
        {
            var numbers = new List<int>();

            var maxD = Fact(9).ToString().Length;
            for (int d = 2; d < maxD; d++)
            {
                var max = (int)Math.Pow(10, d);
                for (int i = (int)Math.Pow(10, d - 1); i < max; i++)
                {
                    if (IsCurious(i))
                    {
                        numbers.Add(i);
                    }
                }
            }

            return numbers.Sum();
        }

        private int Fact(int n)
        {
            var product = 1;
            for (int i = 1; i <= n; i++)
            {
                product *= i;
            }

            return product;
        }

        private bool IsCurious(int n)
        {
            var sum = n.ToString().Select(c => Fact(int.Parse(c.ToString()))).Sum();
            return sum == n;
        }
    }
}
