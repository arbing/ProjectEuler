using System.Collections.Generic;
using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Non-abundant sums")]
    [Description(@"A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.")]
    [Answer(4179871)]
    public class No023
    {
        public long Run()
        {
            const long minAbundant = 12;
            const long maxCanWrittenAsSumOfAbundant = 28123;

            var abundants = new HashSet<long>();
            for (long i = minAbundant; i <= maxCanWrittenAsSumOfAbundant; i++)
            {
                if (IsAbundant(i))
                {
                    abundants.Add(i);
                }
            }

            var sum = 0L;
            for (long i = 1; i <= maxCanWrittenAsSumOfAbundant; i++)
            {
                if (i < minAbundant * 2)
                {
                    sum += i;
                }
                else
                {
                    var r = CanWrittenAsSumOfAbundant(i, abundants);
                    if (!r)
                    {
                        sum += i;
                    }
                }
            }

            return sum;
        }

        public bool CanWrittenAsSumOfAbundant(long n, HashSet<long> abundants)
        {
            foreach (var a in abundants)
            {
                var an = n - a;

                if (an <= 0)
                {
                    continue;
                }

                if (abundants.Contains(an))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsAbundant(long n)
        {
            return GetProperSum(n) > n;
        }

        public long GetProperSum(long n)
        {
            var sum = 0L;
            for (long i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }

    }
}
