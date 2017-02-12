using System;
using System.Threading;

namespace GameOfLife
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var pattern = getPatternFromUser();
            var isAuto = IsTransitionAuto();

            var board = new Board();
            board.SetPattern(pattern);

            if (isAuto)
                RunAuto(board);
            else
                RunManual(board);

        }

        private static void RunManual(Board board)
        {
            var isOver = false;

            while (!isOver)
            {
                Console.Write(board.ToString());
                board = board.NextGeneration();

                Console.WriteLine("Enter 0 to continue or 1 to end:");

                var validInput = false;

                while (!validInput)
                    try
                    {
                        var userInput = int.Parse(Console.ReadLine());
                        if (userInput == 0 || userInput == 1)
                        {
                            isOver = userInput == 1;
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter either 0 or 1");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Please enter a valid number!");
                    }

                Console.Clear();
            }

            Console.WriteLine("Bye");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

        private static void RunAuto(Board board)
        {
            while (true)
            {
                Console.Write(board.ToString());
                board = board.NextGeneration();

                Thread.Sleep(500);
                Console.Clear();
            }
        }

        private static bool IsTransitionAuto()
        {
            var validInput = false;
            var isAuto = false;
            while (!validInput)
            {
                Console.WriteLine("Please select a mode by entering the corresponding number:"
                                  + "\nAuto: 0"
                                  + "\nManual: 1");
                try
                {
                    var userInput = int.Parse(Console.ReadLine());
                    if (userInput == 0 || userInput == 1)
                    {
                        isAuto = userInput == 0;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter either 0 or 1");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter a valid number!");
                }
            }

            return isAuto;
        }

        private static Pattern getPatternFromUser()
        {
            var validInput = false;
            Pattern pattern = Pattern.Random;

            while (!validInput)
            {
                Console.WriteLine("Please select a pattern by entering the corresponding number:"
                                  + "\nBlinker: 0"
                                  + "\nToad: 1"
                                  + "\nBeacon: 2"
                                  + "\nPulsar: 3"
                                  + "\nPentadecathlon: 4"
                                  + "\nRandom: 5");
                try
                {
                    var userInput = int.Parse(Console.ReadLine());
                    if (userInput >= 0 && userInput <= 5)
                    {
                        pattern = (Pattern) userInput;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a value between 0 and 5!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid number!");
                }
            }

            return pattern;
        }
    }
}