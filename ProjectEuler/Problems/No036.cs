using System;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Double-base palindromes")]
    [Description(@"The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.

Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

(Please note that the palindromic number, in either base, may not include leading zeros.)")]
    [Answer(872187)]
    public class No036
    {
        public long Run(long n = 1000 * 1000)
        {
            var sum = 0;
            for (int i = 1; i < n; i++)
            {
                if (IsPalindromic(i))
                {
                    sum += i;
                }
            }
            return sum;
        }

        public bool IsPalindromic(long n)
        {
            var dec = n.ToString();
            var bin = Convert.ToString(n, 2);

            return dec == new string(dec.Reverse().ToArray())
                && bin == new string(bin.Reverse().ToArray());
        }
    }
}
