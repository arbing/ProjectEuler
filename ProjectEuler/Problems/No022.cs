using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Names scores")]
    [Description(@"Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

What is the total of all the name scores in the file?")]
    [Answer(871198282)]
    public class No022
    {
        public long Run()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\p022_names.txt");
            var txt = File.ReadAllText(path);
            var names = txt.Trim('"').Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(names);

            var totalscore = 0;
            for (int i = 0; i < names.Length; i++)
            {
                var index = i + 1;

                var worth = names[i].Select(c => char.ToUpper(c) - 'A' + 1).Sum();

                var score = index * worth;

                totalscore += score;
            }

            return totalscore;
        }
    }
}
