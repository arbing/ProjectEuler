using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Number spiral diagonals")]
    [Description(@"Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

21 22 23 24 25
20  7  8  9 10
19  6  1  2 11
18  5  4  3 12
17 16 15 14 13

It can be verified that the sum of the numbers on the diagonals is 101.

What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?")]
    [Answer(669171001)]
    public class No028
    {
        public long Run(int n = 1001)
        {
            var matrix = new int[n][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[n];
            }

            var r = n / 2;
            var c = n / 2;

            int curdir = 0;
            for (int i = 1; i <= n * n; i++)
            {
                matrix[r][c] = i;

                curdir = Clockwise(curdir, matrix, ref r, ref c);
            }

            var sum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                sum += matrix[i][i];
                sum += matrix[i][matrix.Length - i - 1];
            }

            return sum - 1;
        }

        public int Clockwise(int current, int[][] matrix, ref int r, ref int c)
        {
            var nextr = r;
            var nextc = c;
            if (current % 4 == 0)
            {
                nextc++;
            }
            else if (current % 4 == 1)
            {
                nextr++;
            }
            else if (current % 4 == 2)
            {
                nextc--;
            }
            else if (current % 4 == 3)
            {
                nextr--;
            }

            // continue
            if (matrix[nextr][nextc] > 0)
            {
                current--;
            }

            if (current % 4 == 0)
            {
                c++;
            }
            else if (current % 4 == 1)
            {
                r++;
            }
            else if (current % 4 == 2)
            {
                c--;
            }
            else if (current % 4 == 3)
            {
                r--;
            }

            return current + 1;
        }
    }
}
