using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Power digit sum")]

    [Description(@"215 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

What is the sum of the digits of the number 21000?")]
    [Answer(1366)]
    public class No016
    {
        public long Run(int n = 1000)
        {
            var powerDigits = new List<int>() { 2 };
            for (int c = 0; c < n - 1; c++)
            {
                AddSelf(powerDigits);
            }

            var sumOfDigits = powerDigits.Select(i => (long)i).Sum();

            return sumOfDigits;
        }

        private void AddSelf(List<int> digits)
        {
            var addBits = digits.ToArray();

            for (int i = 0; i < addBits.Length; i++)
            {
                AddBitByBit(digits, i, addBits[i]);
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
