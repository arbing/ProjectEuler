using System.ComponentModel;
using System.Numerics;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("1000-digit Fibonacci number")]
    [Description(@"The Fibonacci sequence is defined by the recurrence relation:

Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
Hence the first 12 terms will be:

F1 = 1
F2 = 1
F3 = 2
F4 = 3
F5 = 5
F6 = 8
F7 = 13
F8 = 21
F9 = 34
F10 = 55
F11 = 89
F12 = 144
The 12th term, F12, is the first term to contain three digits.

What is the index of the first term in the Fibonacci sequence to contain 1000 digits?")]
    [Answer(4782)]
    public class No025
    {
        public long Run(long n = 1000)
        {
            var i = 3L;
            var fn1 = new BigInteger(1);
            var fn2 = new BigInteger(1);
            var fn = new BigInteger(0);

            while (true)
            {
                fn = fn1 + fn2;

                if (fn.ToString().Length == n)
                {
                    return i;
                }

                fn1 = fn2;
                fn2 = fn;

                i++;
            }
        }
    }
}
