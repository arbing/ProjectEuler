using System;
using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Lattice paths")]
    [Description(@"Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.


How many such routes are there through a 20×20 grid?")]
    [Answer(137846528820)]
    public class No015
    {
        public long Run(long n = 20)
        {
            // C(2n, n) = (2n)! / (n! * (2n-n)!) 
            // = 2n * (2n-1) * ... * n * ... * 1 / (n * ... * 1 * n * ... * 1)
            // = 2n * (2n-1) * ... * (n + 1) / (n * ... * n / 2 * ... * 1)
            // = 2 * (2n-1) * 2 * (2n-3) * ... * 2 * (n + 1) / (n / 2 * ... * 1)
            // = 2^n * (2n-1) * ... * (n + 1) / (n / 2 * ... * 1)

            var paths = Math.Pow(2, n / 2);
            for (long i = 2 * n - 1; i >= n + 1; i -= 2)
            {
                paths *= i;
            }

            for (long i = n / 2; i >= 1; i--)
            {
                paths /= i;
            }

            //var paths = 1D;
            //for (long i = n + 1; i <= 2 * n; i++)
            //{
            //    paths *= i;
            //}

            //for (long i = n; i >= 1; i--)
            //{
            //    paths /= i;
            //}

            return (long)paths;
        }
    }
}
