using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Number letter counts")]
    [Description(@"If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?


NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of ""and"" when writing out numbers is in compliance with British usage.")]
    [Answer(233168)]
    public class No017
    {
        public long Run(long n = 1000)
        {
            var count = 0;
            for (int i = 1; i <= n; i++)
            {
                var words = ToWords(i);
                count += words.Replace(" ", "").Replace("-", "").Length;
            }

            return count;
        }

        private string ToWords(int n)
        {
            var baseMap = new string[] {
                "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty"
            };

            var tensMap = new string[] {
                "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
            };

            if (0 < n && n <= 20)
            {
                return baseMap[n - 1];
            }
            else if (20 < n && n < 100)
            {
                var tensWords = tensMap[n / 10 - 1];

                if (n % 10 == 0)
                {
                    return tensWords;
                }
                else
                {
                    var onesWords = ToWords(n % 10);

                    return $"{tensWords}-{onesWords}";
                }
            }
            else if (100 <= n && n < 1000)
            {
                var hundredsWords = $"{baseMap[n / 100 - 1]} hundred";

                if (n % 100 == 0)
                {
                    return hundredsWords;
                }
                else
                {
                    var tensWords = ToWords(n % 100);
                    return $"{hundredsWords} and {tensWords}";
                }
            }
            else if (n == 1000)
            {
                var thousandsWords = $"{baseMap[n / 1000 - 1]} thousand";
                return thousandsWords;
            }
            else
            {
                return "todo";
            }
        }
    }
}
