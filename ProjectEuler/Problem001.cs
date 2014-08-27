﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem001
    {
        public static int Run(int number = 1000)
        {
            return Enumerable.Range(1, number - 1)
                .Where(n => n % 3 == 0 || n % 5 == 0)
                .Sum();
        }
    }
}
