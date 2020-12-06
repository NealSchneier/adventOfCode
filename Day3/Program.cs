using System;
using System.Collections.Generic;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllLines("input.txt");
            var slope = new Slope { Down = 1, Right = 3};
            var terrain = new Terrain();
            terrain.Land = new List<bool>[text.Length];
            var currentPosition = new Position();
            var nextPosition = new Position{
                x = slope.Right,
                y = slope.Down
            };
            //parse the terrain
            for (var i = 0; i < text.Length; i++)
            {
                var currentTerrain = new List<bool>();
                foreach(char c in text[i])
                {
                    currentTerrain.Add(c == '#');
                }
                terrain.Land[i] = currentTerrain;
            }
            
            //follow the tree down
            for (var i = 0; i < terrain.Land.Length; i++)
            {
                var row = terrain.Land[i];
                var xPosition = currentPosition.x;
                if (currentPosition.x > row.Count)
                {
                    xPosition = xPosition % row.Count;
                }
                if (row[xPosition]) currentPosition.TreeCount += 1;
                currentPosition.x = currentPosition.x +slope.Right;
                currentPosition.y = currentPosition.y +slope.Down;

            }
            Console.WriteLine(currentPosition.x);
            Console.WriteLine(currentPosition.y);
            Console.WriteLine(currentPosition.TreeCount);
        }
    }
}
