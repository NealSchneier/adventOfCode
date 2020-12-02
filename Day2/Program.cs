using System;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllLines("input.txt");
            Part1(text);
            Part2(text);
        }
        private static void Part2(string[] text)
        {
            var validCount = 0;
            foreach (var line in text)
            {
                var items = line.Split(' ');
                var firstNumber = int.Parse(items[0].Split('-')[0]);
                var secondNumber = int.Parse(items[0].Split('-')[1]);
                var character = items[1].ToCharArray()[0];
                var characters = items[2].ToCharArray();
                var firstChar = characters[firstNumber - 1];
                var secondChar = characters[secondNumber - 1];
                
                if ((firstChar == character && secondChar != character) || (firstChar != character && secondChar == character))
                {
                    validCount += 1;
                }
            }
            Console.WriteLine("Part 2 " + validCount);
        }

        private static void Part1(string[] text)
        {
            var validCount = 0;
            foreach (var line in text)
            {
                var items = line.Split(' ');
                var firstNumber = int.Parse(items[0].Split('-')[0]);
                var secondNumber = int.Parse(items[0].Split('-')[1]);
                var character = items[1].ToCharArray()[0];
                var countCharacters = items[2].ToCharArray().ToList().Where(x => x == character).Count();
                if (countCharacters >= firstNumber && countCharacters <= secondNumber)
                {
                    validCount += 1;
                }
            }
            Console.WriteLine("Part 1 " + validCount);
        }
    }
}
