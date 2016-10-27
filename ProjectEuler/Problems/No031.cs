using System.ComponentModel;
using ProjectEuler.Attributes;

namespace ProjectEuler.Problems
{
    [Title("Coin sums")]
    [Description(@"In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
It is possible to make £2 in the following way:

1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
How many different ways can £2 be made using any number of coins?")]
    [Answer(73682)]
    public class No031
    {
        public long Run(long n = 200)
        {
            var ways = 0;
            for (int a = 0; a <= n / 1; a++)
            {
                for (int b = 0; b <= n / 2; b++)
                {
                    if (a + 2 * b > n)
                    {
                        break;
                    }

                    for (int c = 0; c <= n / 5; c++)
                    {
                        if (a + 2 * b + 5 * c > n)
                        {
                            break;
                        }

                        for (int d = 0; d <= n / 10; d++)
                        {
                            if (a + 2 * b + 5 * c + 10 * d > n)
                            {
                                break;
                            }

                            for (int e = 0; e <= n / 20; e++)
                            {
                                if (a + 2 * b + 5 * c + 10 * d + 20 * e > n)
                                {
                                    break;
                                }

                                for (int f = 0; f <= n / 50; f++)
                                {
                                    if (a + 2 * b + 5 * c + 10 * d + 20 * e + 50 * f > n)
                                    {
                                        break;
                                    }

                                    for (int g = 0; g <= n / 100; g++)
                                    {
                                        if (a + 2 * b + 5 * c + 10 * d + 20 * e + 50 * f + 100 * g > n)
                                        {
                                            break;
                                        }

                                        for (int h = 0; h <= n / 200; h++)
                                        {
                                            if (a + 2 * b + 5 * c + 10 * d + 20 * e + 50 * f + 100 * g + 200 * h == n)
                                            {
                                                ways++;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ways;
        }
    }
}
