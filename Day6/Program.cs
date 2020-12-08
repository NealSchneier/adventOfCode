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
            int count = 0;
            foreach(var doc in customsDocs)
            {
                var array = doc.Replace("\r\n", "").ToCharArray();
                var list = new List<string>();
                foreach(var c in array)
                {
                    list.Add(c.ToString());
                }
                count += list.Distinct().Count();
            }
            Console.WriteLine(count);
        }
    }
}
