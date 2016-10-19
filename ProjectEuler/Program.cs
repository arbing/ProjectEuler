using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using ProjectEuler.Attributes;

namespace ProjectEuler
{
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Please enter the Problem No: ");
                    var n = Convert.ToInt32(Console.ReadLine());

                    var problem = string.Format("No{0}", n.ToString("000"));
                    var problems = FindProblems();

                    var type = problems.First(t => t.FullName.EndsWith(problem));
                    var titleAttribute = type.GetCustomAttribute(typeof(TitleAttribute)) as TitleAttribute ?? new TitleAttribute();
                    var title = titleAttribute.Title;
                    var descriptionAttribute = type.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute ?? DescriptionAttribute.Default;
                    var description = descriptionAttribute.Description;
                    var answerAttribute = type.GetCustomAttribute(typeof(AnswerAttribute)) as AnswerAttribute ?? new AnswerAttribute();
                    var answer = answerAttribute.Answer;

                    var method = type.GetMethod("Run");
                    var parameters = method.GetParameters()
                        .Where(p => p.HasDefaultValue)
                        .Select(p => p.DefaultValue).ToArray();
                    var obj = Activator.CreateInstance(type);

                    Console.WriteLine("Problem {0} : {1}", n, title);
                    Console.WriteLine();
                    Console.WriteLine("{0}", description);
                    Console.WriteLine();
                    Console.WriteLine("Answer  : {0}", answer);
                    Console.WriteLine("Running ...");

                    var stopwatch = Stopwatch.StartNew();
                    //var calculateTiming = new CalculateTiming();
                    //calculateTiming.Start();

                    var result = method.Invoke(obj, parameters);

                    stopwatch.Stop();
                    //calculateTiming.Stop();

                    Console.WriteLine("Result is {0}", result);
                    Console.WriteLine("Spend {0} milliseconds", stopwatch.Elapsed.TotalMilliseconds);
                    //Console.WriteLine("Spend {0} milliseconds", calculateTiming.Result().TotalMilliseconds);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }
        }

        static List<Type> FindProblems()
        {
            var problems = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "ProjectEuler.Problems");
            return problems.ToList();
        }
    }
}
