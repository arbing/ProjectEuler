using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Amicable numbers")]
    [Description(@"Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.")]
    [Answer(31626)]
    public class No021
    {
        public long Run(int n = 10000)
        {
            var fns = new List<int>() { 0 };
            for (int i = 1; i < n; i++)
            {
                var sum = SumProperDivisors(i);
                fns.Add(sum);
            }

            var amicables = new HashSet<int>();
            for (int i = 0; i < fns.Count; i++)
            {
                var a = fns[i];
                if (a != i && a < fns.Count && fns[a] == i)
                {
                    amicables.Add(i);
                    amicables.Add(a);
                }
            }

            return amicables.Sum();
        }

        public int SumProperDivisors(int n)
        {
            var sum = 0;

            for (int i = 1; i < n; i++)
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
