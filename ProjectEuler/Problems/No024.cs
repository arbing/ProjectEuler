using System.ComponentModel;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Lexicographic permutations")]
    [Description(@"A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

012   021   102   120   201   210

What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?")]
    [Answer(2783915460)]
    public class No024
    {
        public long Run(long n = 1000 * 1000)
        {
            var countLex = 0L;
            var lex = "";
            var num = Enumerable.Range(0, 10).ToList();

            while (true)
            {
                var i = 0;

                var f = Factorial(num.Count - 1);

                while (countLex + f < n)
                {
                    countLex += f;
                    i++;
                }

                lex += num[i].ToString();
                num.RemoveAt(i);

                if (num.Count == 0)
                {
                    break;
                }
            }

            return long.Parse(lex);
        }

        public long Factorial(int n)
        {
            var mul = 1;
            for (int i = n; i > 0; i--)
            {
                mul *= i;
            }

            return mul;
        }

        public long Run1(long n = 1000 * 1000)
        {
            var lex = 123456789L;
            var countLex = 0;

            while (lex < 10000000000L)
            {
                if (IsPermutation(lex, 10))
                {
                    countLex++;
                }

                if (countLex == n)
                {
                    break;
                }

                lex++;
            }

            return lex;
        }

        public bool IsPermutation(long n, int len)
        {
            var bit = new bool[len];

            while (n != 0)
            {
                var remainder = n % 10;
                if (bit[remainder])
                {
                    return false;
                }

                bit[remainder] = true;

                n /= 10;
            }

            if (!bit[0])
            {
                return bit.Skip(1).All(b => b);
            }
            else
            {
                return bit.All(b => b);
            }
        }
    }
}
