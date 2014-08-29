using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    using System.Globalization;
    using System.Security.Cryptography;

    public class Problem004
    {
        public static long Run(long number = 3)
        {
            var min = (int)Math.Pow(10, number - 1);
            var max = (int)Math.Pow(10, number) - 1;

            var numbers = from x in Enumerable.Range(min, max - min + 1)
                          join y in Enumerable.Range(min, max - min + 1) on 0 equals 0
                          orderby x * y 
                          select x * y;

            return GetPalindromic(numbers.Distinct());
        }

        public static int GetPalindromic(IEnumerable<int> numbers)
        {
            Predicate<int> condition =
                n =>
                {
                    var chars = n.ToString(CultureInfo.InvariantCulture).ToCharArray();
                    for (var i = 0; i < chars.Length / 2; i++)
                    {
                        if (chars[i] != chars[chars.Length - 1 - i])
                        {
                            return false;
                        }
                    }
                    return true;
                };

            return numbers.Reverse().FirstOrDefault(n => condition(n));
        }
    }
}
