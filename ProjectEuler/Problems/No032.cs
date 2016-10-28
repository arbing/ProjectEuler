using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Pandigital products")]
    [Description(@"We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.

The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.

HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.")]
    [Answer(45228)]
    public class No032
    {
        public long Run(int n = 9)
        {
            var pandigitals = new HashSet<int>();
            for (int i = 2; i < 100; i++)
            {
                for (int j = 100; j < 10000; j++)
                {
                    var mul = i * j;
                    var com = i.ToString() + j + mul;
                    if (IsPandigital(com, n))
                    {
                        pandigitals.Add(mul);
                    }
                }
            }
            return pandigitals.Sum();
        }

        private bool IsPandigital(string com, int n)
        {
            if (com.Length == n && !com.Contains('0'))
            {
                foreach (var c in com)
                {
                    if (com.Count(d => d == c) > 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
