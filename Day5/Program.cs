using System;

namespace Day5
{
    class Program
    {
        private const int HigherBound = 127;
        private const int LowerBound = 0;

        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllLines("Day5/input.txt");
            TestPart1(text);
        }

        public static void TestPart1(string[] text)
        {
            var highestSeatId = 0;
            foreach(var row in text)
            {
                var position = new Position();
                position = Switch(row[0], LowerBound, HigherBound, position);
                position = NewMethod(row[1], position, LowerBound, HigherBound);
                position = Switch(row[1], 0, HigherBound, position);
                position = Switch(row[2], 0, HigherBound, position);
                position = Switch(row[3], 0, HigherBound, position);
                position = Switch(row[4], 0, HigherBound, position);
                position = Switch(row[5], 0, HigherBound, position);
                position = Switch(row[6], 0, HigherBound, position);
            }
        }

        private static Position NewMethod(char c, Position position, int lower, int higher)
        {
            if (position.lower == lower)
            {
                position = Switch(c, lower, higher / 2, position);
            }
            else
            {
                position = Switch(c, higher / 2, higher, position);
            }

            return position;
        }

        public static Position Switch(char c, int lowerBound, int higherBound, Position position)
        {
            switch(c){
                    case 'F': 
                        position.higher = higherBound / 2;
                        position.lower = lowerBound;
                        break;
                    case 'B':
                        position.lower = higherBound / 2;
                        position.higher = higherBound;
                        break; 
            }
            return position;
        }
    }
    class Row
    {
        public char[] row;
    }
    class Position
    {
        public int lower;
        public int higher;
    }
}
