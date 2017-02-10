using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        private static Pattern pattern;

        static void Main(string[] args)
        {
            getPatternFromUser();
            Console.WriteLine($"Pattern is {pattern}");
            Console.ReadKey();
        }

        private static void getPatternFromUser()
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Please select a pattern by entering the corresponding number:"
                                  + "\nBlinker: 0"
                                  + "\nToad: 1"
                                  + "\nBeacon: 2"
                                  + "\nPulsar: 3"
                                  + "\nPentadecathlon: 4");
                var userInput = int.Parse(Console.ReadLine());
                if (userInput >= 0 && userInput <= 4)
                {
                    pattern = (Pattern) userInput;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Please enter a value between 0 and 4!");
                }
            }
        }
    }
}
