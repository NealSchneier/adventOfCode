using System;
using System.Collections.Generic;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllLines("input.txt");
            var slope = new Slope { Down = 1, Right = 3 };
            var terrain = new Terrain();
            terrain.Land = new List<bool>[text.LongLength];
            var currentPosition = new Position();
            //parse the terrain
            for (var i = 0; i < text.Length; i++)
            {
                var currentTerrain = new List<bool>();
                foreach (char c in text[i])
                {
                    currentTerrain.Add(c == '#');
                }
                terrain.Land[i] = currentTerrain;
            }

            Part1(slope, terrain, currentPosition);

            var slope1Position = new Position();
            var slope1 = Part2(slope, terrain, slope1Position);
            
            var slope2Position = new Position();
            slope = new Slope { Down = 1, Right = 1 };
            var slope2 = Part2(slope, terrain, slope2Position);

            var slope3Position = new Position();
            slope = new Slope { Down = 1, Right = 5 };
            var slope3 = Part2(slope, terrain, slope3Position);

            var slope4Position = new Position();
            slope = new Slope { Down = 1, Right = 7 };
            var slope4 = Part2(slope, terrain, slope4Position);

            var slope5Position = new Position();
            slope = new Slope { Down = 2, Right = 1 };
            var slope5 = Part2(slope, terrain, slope5Position);

            Console.WriteLine(slope1 * slope2 * slope3 * slope4 * slope5);
        }

        private static long Part2(Slope slope, Terrain terrain, Position currentPosition)
        {
            //follow the tree down
            for (long i = 0; i < terrain.Land.Length; i = i + slope.Down) 
            {
                var row = terrain.Land[i];
                int xPosition = currentPosition.x;
                if (currentPosition.x >= row.Count)
                {
                    xPosition = xPosition % row.Count;
                }
                if (row[xPosition]) currentPosition.TreeCount += 1;
                currentPosition.x = currentPosition.x + slope.Right;
                currentPosition.y = currentPosition.y + slope.Down;

            }
            Console.WriteLine("Part 2 " +currentPosition.TreeCount);
            return currentPosition.TreeCount;
        }

        private static void Part1(Slope slope, Terrain terrain, Position currentPosition)
        {
            for (long i = 0; i < terrain.Land.Length; i = i + slope.Down) 
            {
                var row = terrain.Land[i];
                int xPosition = currentPosition.x;
                if (currentPosition.x > row.Count)
                {
                    xPosition = xPosition % row.Count;
                }
                if (row[xPosition]) currentPosition.TreeCount += 1;
                currentPosition.x = currentPosition.x + slope.Right;
                currentPosition.y = currentPosition.y + slope.Down;

            }
            Console.WriteLine("Part 1 " +currentPosition.TreeCount);
            
        }
    }
}
