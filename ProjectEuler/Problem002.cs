using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem002
    {
        public static int Run(int number = 4 * 1000 * 1000)
        {
            var sequence = GetFibonacciSequence(number);
            return sequence.Where(n => n % 2 == 0).Sum();
        }

        public static IEnumerable<int> GetFibonacciSequence(int number)
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
