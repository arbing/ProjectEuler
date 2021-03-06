﻿using System;
using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Highly divisible triangular number")]
    [Description(@"The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:

1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

Let us list the factors of the first seven triangle numbers:

 1: 1
 3: 1,3
 6: 1,2,3,6
10: 1,2,5,10
15: 1,3,5,15
21: 1,3,7,21
28: 1,2,4,7,14,28
We can see that 28 is the first triangle number to have over five divisors.

What is the value of the first triangle number to have over five hundred divisors?")]
    [Answer(76576500)]
    public class No012
    {
        public long Run(long n = 500)
        {
            var triangular = 0;
            for (int i = 1; ; i++)
            {
                triangular += i;

                var factor = 0;

                var sqrt = (int)Math.Sqrt(triangular) + 1;
                for (int j = 1; j < sqrt; j++)
                {
                    if (triangular % j == 0)
                    {
                        factor += 2;
                    }
                }

                if (triangular == sqrt * sqrt)
                {
                    factor--;
                }

                if (factor >= n)
                {
                    return triangular;
                }
            }
        }
    }
}
