using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Multiples of 3 and 5")]
    [Description(@"If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

Find the sum of all the multiples of 3 or 5 below 1000.")]
    [Answer(233168)]
    public class No001
    {
        public long Run(long number = 1000)
        {
            return Enumerable.Range(1, (int)number - 1)
                .Where(n => n % 3 == 0 || n % 5 == 0)
                .Sum();
        }
    }
}
