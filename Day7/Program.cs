using System;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllLines("Day7/input.txt");
            Console.WriteLine("Hello World!");
        }
    }
    class Bags
    {
        public string color;
        public int count;
        public List<Bag> bags;
    }
}
