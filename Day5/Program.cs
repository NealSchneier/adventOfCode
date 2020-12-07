using System;

namespace Day5
{
    class Program
    {

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
                foreach (var c in row)
                {
                    position = Switch(c, LowerBound, HigherBound, position);
                    position = NewMethod(c, position, LowerBound, HigherBound);
                    
                }
               
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
        public int lower = 0;
        public int higher = 127;
    }
}
