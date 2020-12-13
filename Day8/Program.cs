using System;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var accumulator = 0;
            var text = System.IO.File.ReadAllText("Day8/input.txt");
            var lines = text.Split("\n");
            bool[] commandRan = new bool[lines.Length];
            for(var i = 0; i < lines.Length; i++)
            {
                if (commandRan[i])
                {
                    Console.WriteLine(accumulator);
                    return;
                }
                commandRan[i] = true;
                var command = lines[i].Trim().Split(" ");
                if (command[0] == "acc")
                {
                    var isPositive = command[1].Substring(0, 1) == "+";
                    if (isPositive)
                    {
                       accumulator += int.Parse(command[1].Substring(1, command[1].Length - 1));
                    }
                    else 
                    {
                        accumulator -= int.Parse(command[1].Substring(1, command[1].Length - 1));
                    }
                }
                else if (command[0] == "nop")
                {
                    continue;
                }
                else if (command[0] == "jmp")
                {
                    var isPositive = command[1].Substring(0, 1) == "+";
                    if (isPositive)
                    {
                        i += int.Parse(command[1].Substring(1, command[1].Length - 1)) - 1;
                    }
                    else 
                    {
                        i -= int.Parse(command[1].Substring(1, command[1].Length - 1)) + 1;
                    }
                }
            }
            Console.WriteLine(TestInput);
        }
        public static string TestInput = @"nop +0
        acc +1
        jmp +4
        acc +3
        jmp -3
        acc -99
        acc +1
        jmp -4
        acc +6";
    }

    
}
