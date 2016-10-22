using System.ComponentModel;
using System.Numerics;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Reciprocal cycles")]
    [Description(@"A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

1/2	= 	0.5
1/3	= 	0.(3)
1/4	= 	0.25
1/5	= 	0.2
1/6	= 	0.1(6)
1/7	= 	0.(142857)
1/8	= 	0.125
1/9	= 	0.(1)
1/10	= 	0.1
Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.")]
    [Answer(233168)]
    public class No026
    {
        public long Run(long n = 1000)
        {
            var max = 0L;
            var maxRc = 0L;
            for (int i = 2; i < n; i++)
            {
                var rc = GetRecurringCycle(i);
                if (rc > maxRc)
                {
                    maxRc = rc;
                    max = i;
                }
            }

            return max;
        }

        public long GetRecurringCycle(long n)
        {
            if (n % 2 == 0 || n % 5 == 0)
            {
                return 0;
            }

            var i = 1L;

            while (true)
            {
                var m = BigInteger.Pow(10, (int)i) - 1;
                if (m % n == 0)
                {
                    return i;
                }

                i++;
            }
        }
    }
}
