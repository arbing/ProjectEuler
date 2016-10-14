using System;
using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Counting Sundays")]
    [Description(@"You are given the following information, but you may prefer to do some research for yourself.

1 Jan 1900 was a Monday.
Thirty days has September,
April, June and November.
All the rest have thirty-one,
Saving February alone,
Which has twenty-eight, rain or shine.
And on leap years, twenty-nine.
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?")]
    [Answer(233168)]
    public class No019
    {
        public long Run()
        {
            var sum = 0;
            for (DateTime d = new DateTime(1901, 1, 1);
                d <= new DateTime(2000, 12, 31);
                d = d.AddDays(1))
            {
                if (d.DayOfWeek == DayOfWeek.Sunday && d.Day == 1)
                {
                    sum++;
                }
            }
            return sum;
        }

    }
}
