using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    using System.Globalization;
    using System.Security.Cryptography;

    public class Problem005
    {
        public static long Run(long number = 20)
        {
            var factors = Enumerable.Range(1, (int)number);
            var min = (long)factors.Max();

            var n = min;
            var result = n;
            while (true)
            {
                if (factors.All(f => n % f == 0))
                {
                    result = n;
                    break;
                }
                n++;
            }

            return result;
        }
    }
}
