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
                
                position = Switch(row[0], 0, 127, position);
                position = Switch(row[1], position.lower, position.higher, position);
                position = Switch(row[2], position.lower, position.higher, position);
                position = Switch(row[3], position.lower, position.higher, position);
                position = Switch(row[4], position.lower, position.higher, position);
                position = Switch(row[5], position.lower, position.higher, position);
                position = Switch(row[6], position.lower, position.higher, position);
                
                Console.WriteLine(position.higher + " " + position.lower);
                var seatPosition = new Position {lower = 0, higher = 7};

                for (var i = 7; i < 10; i++)
                {
                    seatPosition = SwitchSeat(row[i], seatPosition.lower, seatPosition.higher, seatPosition, i);
                }
                if (seatPosition.lower + position.lower * 8 > highestSeatId)
                {
                    highestSeatId = seatPosition.lower + position.lower * 8;
                }
            }
            Console.WriteLine(highestSeatId);
        }

        public static Position Switch(char c, int lower, int higher, Position position)
        {
            switch(c){
                    case 'F': 
                        position.higher = (higher + lower )/ 2;
                        position.lower = lower;
                        break;
                    case 'B':
                        position.lower = (higher + lower )/ 2 + 1;
                        position.higher = higher;
                        break; 
            }
            return position;
        }
        public static Position SwitchSeat(char c, int lower, int higher, Position position, int i)
        {
            switch(c){
                    case 'L': 
                        position.higher = (higher + lower )/ 2;
                        position.lower = lower;
                        break;
                    case 'R':
                        position.lower = (higher + lower )/ 2 + 1;
                        position.higher = higher;
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
