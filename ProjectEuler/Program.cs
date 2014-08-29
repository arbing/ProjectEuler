using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    using System.Diagnostics;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the Problem No: ");

                    var n = Convert.ToInt32(Console.ReadLine());
                    var problem = string.Format("Problem{0}", n.ToString("000"));
                    var type = Type.GetType("ProjectEuler." + problem);

                    Console.WriteLine("Running {0}:", problem);

                    var stopwatch = Stopwatch.StartNew();

                    var result = type.InvokeMember(
                        "Run",
                        BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static | BindingFlags.OptionalParamBinding,
                        null,
                        null,
                        new object[] { });

                    stopwatch.Stop();

                    Console.WriteLine("Result is {0}", result);
                    Console.WriteLine("Spend {0} seconds", stopwatch.Elapsed.TotalMilliseconds);
                    Console.WriteLine();

                    Console.WriteLine("Type exit to exit, other continue:");

                    if (Console.ReadLine() == "exit")
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}
