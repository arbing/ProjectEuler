﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Even Fibonacci numbers")]
    [Description(@"Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:

1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.")]
    [Answer(4613732)]
    public class No002
    {
        public long Run(long n = 4 * 1000 * 1000)
        {
            var sequence = GetFibonacciSequence(n);
            return sequence.Where(f => f % 2 == 0).Sum();
        }

        public IEnumerable<long> GetFibonacciSequence(long number)
        {
            var x = 0;
            var y = 1;

            while (true)
            {
                var z = x + y;

                if (z >= number)
                {
                    yield break;
                }

                yield return z;

                x = y;
                y = z;
            }
        }
    }
}