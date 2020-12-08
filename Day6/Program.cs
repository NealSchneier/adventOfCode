using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText("Day6/input.txt");
            var customsDocs = text.Split(Environment.NewLine + Environment.NewLine);
            //Part1(customsDocs);
            Part2(customsDocs);
        }
        private static void Part2(string[] customsDocs)
        {
            int count = 0;
            foreach (var doc in customsDocs)
            {
                var persons = doc.Split("\r\n");
                var answers = new int[26];
                foreach(var person in persons)
                {
                    for(var i = 0; i < person.Length; i++)
                    {
                        var character = person.ToCharArray()[i];
                        answers[Convert(character)] += 1;
                    }
                }
                var cnt = answers.ToList().Where(x => x == persons.Count()).Count();
                count += cnt;
            }
            Console.WriteLine(count);
        }
        
        private static void Part1(string[] customsDocs)
        {
            int count = 0;
            foreach (var doc in customsDocs)
            {
                var array = doc.Replace("\r\n", "").ToCharArray();
                var list = new List<string>();
                foreach (var c in array)
                {
                    list.Add(c.ToString());
                }
                count += list.Distinct().Count();
            }
            Console.WriteLine(count);
        }
        public static int Convert(char c)
        {
            switch(c)
            {
                case 'a': return 0;
                case 'b': return 1;
                case 'c': return 2;
                case 'd': return 3;
                case 'e': return 4;
                case 'f': return 5;
                case 'g': return 6;
                case 'h': return 7;
                case 'i': return 8;
                case 'j': return 9;
                case 'k': return 10;
                case 'l': return 11;
                case 'm': return 12;
                case 'n': return 13;
                case 'o': return 14;
                case 'p': return 15;
                case 'q': return 16;
                case 'r': return 17;
                case 's': return 18;
                case 't': return 19;
                case 'u': return 20;
                case 'v': return 21;
                case 'w': return 22;
                case 'x': return 23;
                case 'z': return 24;
                case 'y': return 25;
            }
            return -1;
        }

    }
}
