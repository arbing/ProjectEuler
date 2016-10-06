using System;
using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Sum square difference")]
    [Description(@"The sum of the squares of the first ten natural numbers is,

12 + 22 + ... + 102 = 385
The square of the sum of the first ten natural numbers is,

(1 + 2 + ... + 10)2 = 552 = 3025
Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.")]
    [Answer(25164150)]
    public class No006
    {
        public long Run(long n = 100)
        {
            //var sequence = Enumerable.Range(1, (int)n).ToArray();
            //var squares = sequence.Select(i => i * i).ToArray();
            //var sumOfSquares = squares.Sum();
            //var squareOfSum = (long)Math.Pow(sequence.Sum(), 2);

            //return squareOfSum - sumOfSquares;

            // (1 + 2 + ... + n) ^ 2 = ((n + 1) * n / 2) ^ 2
            var squareOfSum = (long)Math.Pow((n + 1) * n * 0.5, 2);

            // 1 ^ 2 + 2 ^ 2 + ... + n ^ 2 = n * (n + 1) * (2 * n + 1) / 6
            var sumOfSquares = (long)(n * (n + 1) * (2 * n + 1) / 6.0);

            return squareOfSum - sumOfSquares;
        }

        //public long Run(long n = 100)
        //{
        //    var sequence = Enumerable.Range(1, (int)n).ToArray();
        //    var squares = sequence.Select(i => i * i).ToArray();
        //    var sumOfSquares = squares.Sum();
        //    var squareOfSum = (long)Math.Pow(sequence.Sum(), 2);

        //    return squareOfSum - sumOfSquares;
        //}
    }
}
