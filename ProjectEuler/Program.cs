using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            var result = Problem003.Run();

            stopwatch.Stop();

            Console.WriteLine("Result is {0}",result);
            Console.WriteLine("Spend {0} seconds",stopwatch.Elapsed.TotalSeconds);
            Console.ReadKey();
        }
    }
}
