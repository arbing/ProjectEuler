using System.Collections.Generic;
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
        public long Run(long n = 1000)
        {
            return SumDivisibleBy(n - 1, 3) + SumDivisibleBy(n - 1, 5) - SumDivisibleBy(n - 1, 3 * 5);
        }

        public long SumDivisibleBy(long max, long n)
        {
            var p = max / n;

            return n * (p * (p + 1)) / 2;
        }

        public long Run1(long n = 1000000)
        {
            return LongRangeIterator(1, (int)n - 1)
                .Where(i => i % 3 == 0 || i % 5 == 0)
                .Sum();
        }

        private static IEnumerable<long> LongRangeIterator(long start, long count)
        {
            for (long i = 0; i < count; ++i)
                yield return start + i;
        }
    }
}
