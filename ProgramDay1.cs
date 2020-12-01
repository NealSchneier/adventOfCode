using System;
using System.Diagnostics;
using System.Linq;

namespace advent_code
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = Constants.SampleData;
            var ascendingOrder = list.ToArray();
            var sw = Stopwatch.StartNew();
            
            var part1Found = false;
            var part2Found = false;
            int? part1 = null;
            int? part2 = null;
            for (var i = 0; i < ascendingOrder.Count(); i++)
            {
                if (part1Found && part2Found)
                    break;
                for (var y = i + 1; y < ascendingOrder.Count(); y++)
                {
                    if (!part1Found && Sums2020(ascendingOrder[i], ascendingOrder[y]))
                    {
                        part1 = ascendingOrder[i] * ascendingOrder[y];
                    }
                    for (var x = y + 1; x < ascendingOrder.Count(); x++)
                    {
                        if (!part2Found && Sums2020(ascendingOrder[i], ascendingOrder[y], ascendingOrder[x]))
                        {
                            part2 = ascendingOrder[i] * ascendingOrder[y] * ascendingOrder[x];
                        }
                    }
                }
            }
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(part1);
            Console.WriteLine(part2);
        }
        private static bool Sums2020(int y, int x)
        {
            return x + y == 2020;
        }
        private static bool Sums2020(int y, int x, int i)
        {
            return x + y + i == 2020;
        }

    }
}
