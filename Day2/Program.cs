using System;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllLines("input.txt");
            var validCount = 0;
            foreach(var line in text )
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
            Console.WriteLine(validCount);
        }
    }
}
