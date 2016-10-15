using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Factorial digit sum")]

    [Description(@"n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!")]
    [Answer(648)]
    public class No020
    {
        public long Run(int n = 100)
        {
            var factorialDigits = new List<int>() { 1 };
            for (int c = 2; c <= n; c++)
            {
                Times(factorialDigits, c);
            }

            var sumOfDigits = factorialDigits.Select(i => (long)i).Sum();

            return sumOfDigits;
        }

        private void Times(List<int> digits, int n)
        {
            var addBits = digits.ToArray();

            for (int t = 1; t < n; t++)
            {
                for (int i = 0; i < addBits.Length; i++)
                {
                    AddBitByBit(digits, i, addBits[i]);
                }
            }
        }

        private void AddBitByBit(List<int> digits, int start, int addition)
        {
            var index = start;
            if (index < digits.Count)
            {
                var sum = digits[index] + addition;
                digits[index] = sum % 10;

                if (sum / 10 > 0)
                {
                    AddBitByBit(digits, index + 1, sum / 10);
                }
            }
            else
            {
                digits.Add(addition);
            }
        }
    }
}
