using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day7
{
    // STOLEN FROM REDDIT. It was a much more elegant solution
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GiveMeTheAnswerPart1());
            Console.WriteLine(GiveMeTheAnswerPart2());
        }
       public static int GiveMeTheAnswerPart1()
            => LookUpForAll(File.ReadAllLines("Day7/input.txt").ToList(), "shiny gold")
                .Distinct()
                .Count();

        private static IEnumerable<string> LookUpForAll(List<string> data, string lookingForThat)
        {
            var found = data.Where(d => d.Contains(lookingForThat))
                            .Select(d => d.Split(" bags contain ")[0].Trim())
                            .Where(b => !b.Equals(lookingForThat))
                            .ToList();

            return found.Union((found.Any()) ? found.SelectMany(f => LookUpForAll(data, f)) : new List<string>());
        }

        public static int GiveMeTheAnswerPart2()
            => LookDownForAll(File.ReadAllLines("Day7/input.txt").ToList(), "shiny gold");

        private static int LookDownForAll(List<string> data, string lookingForThat)
        {
            static int ExtractQtt(string b) => Convert.ToInt32(b.Split(" ")[0]);
            static string ExtractLabel(string b) => string.Join(' ', b.Split(" ").Skip(1));

            var bags = data.Where(d => d.StartsWith(lookingForThat))
                .Select(b => b.Split(" bags contain ")[1].Replace(".", ""))
                .SelectMany(l => l.Split(", "))
                .Where(b => !b.Contains("no other bags"))
                .Select(b => b.Replace("bags", "").Replace("bag", "").Trim())
                .Select(b => (ExtractQtt(b), ExtractLabel(b)))
                .ToList();

            return bags.Any() ?
                bags.Select(b => b.Item1 + (b.Item1 * LookDownForAll(data, b.Item2))).Sum()
                : 0;
        }
    }
    
    class Bags
    {
        public int count;
        public Dictionary<string, Bags> children = new Dictionary<string, Bags>();
    }
}
