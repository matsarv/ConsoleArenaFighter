using System;

namespace ConsoleArenaFighter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepAlive = true;
            while (keepAlive)
            {
                Console.WriteLine(
                    "--- Arena Fighter Menu ---\n" +
                    "  1: Throw Dice\n" +
                    "  0: Exit program\n"
                    );
                int selection = AskUserForNumberX("Select menu number");

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Dice number: " + ThrowDice() );
                        break;
                    case 0:
                        keepAlive = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid selection.");
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true); 
                Console.Clear(); 
            }

        }






        static int ThrowDice() // add to class Round
        {
            Random random = new Random();  // Get random cust
            int dice = random.Next(1, 6);
            return dice;
        }

        // Ask for Input string
        static string AskUserForX(string x)
        {
            string input = "";

            while (input.Length == 0)
            {
                Console.Write(x + ": "); //Ask for text with input string
                input = Console.ReadLine();
            }

            return input;
        }

        // Ask for Input number
        static int AskUserForNumberX(string x)
        {
            int number = 0;
            bool noNumber = true;
            while (noNumber)
            {
                try
                {
                    number = Convert.ToInt32(AskUserForX(x)); // Ask for number with string
                    noNumber = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a number. Please try once more.");
                }
            }

            return number;

        }
    }

    
}
