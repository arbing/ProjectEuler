using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Largest palindrome product")]
    [Description(@"A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

Find the largest palindrome made from the product of two 3-digit numbers.")]
    [Answer(906609)]
    public class No004
    {
        public long Run(long n = 3)
        {
            var min = (int)Math.Pow(10, n - 1);
            var max = (int)Math.Pow(10, n) - 1;

            var numbers = from x in Enumerable.Range(min, max - min + 1)
                          from y in Enumerable.Range(min, max - min + 1)
                          let z = x * y
                          orderby z descending
                          select z;

            return GetPalindromic(numbers.Distinct());
        }

        public static int GetPalindromic(IEnumerable<int> numbers)
        {
            Predicate<int> condition =
                n =>
                {
                    var chars = n.ToString().ToCharArray();
                    for (var i = 0; i < chars.Length / 2; i++)
                    {
                        if (chars[i] != chars[chars.Length - 1 - i])
                        {
                            return false;
                        }
                    }
                    return true;
                };

            return numbers.FirstOrDefault(n => condition(n));
        }
    }
}
