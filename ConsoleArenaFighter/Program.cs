
//using ConsoleArenaFighterCharacter;
using Lexicon.CSharp.InfoGenerator;
using System;

namespace ConsoleArenaFighter
{
    class Program
    {
        static InfoGenerator InfoGen = new InfoGenerator(DateTime.Now.Millisecond);

        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.White;

            // Player enter Character
            Character player = CreatePlayer();
            Console.Clear();

            player.DisplayCharacter();
            Console.WriteLine();

            DisplayMessage(
            "What do you want to do?\n" +
            "H - Hunt for an opponent\n" +
            "R - Retire from fighting\n"
            );
            //string selection = AskUserForX(""); // keyInput
            char play = Console.ReadKey(true).KeyChar;
            switch (play)
            {
                case 'h':
                    // goto battle - use classes in battle

                    Console.Clear();
                    Character opponent = CreateOpponent();
                    Console.WriteLine("Player:");
                    player.DisplayCharacter();
                    Console.WriteLine();
                    Console.WriteLine("Opponent:");
                    opponent.DisplayCharacter();

                    Console.WriteLine("start battle");
                    Console.ReadKey();

                    break;

                case 'r':
                    Console.WriteLine("You have ended the violence by not fighting.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Final Statistics: \n");
                    player.DisplayCharacter();
                    Console.WriteLine(player.Name + " total score is " + player.score + ".");
                    break;

                default:
                    break;
            }
            Console.ReadKey();
        }

        // Create player from input
        static Character CreatePlayer()
        {
            string name = AskUserForX("Enter the name of your character");
            int strenght = AskUserForNumberX("Enter strenght (between 1-9)");
            int damage = AskUserForNumberX("Enter damage (between 1-5)");
            int health = AskUserForNumberX("Enter strenght (between 1-9)");
            int score = 0;
            return new Character(name, strenght, damage, health, score);
            
        }

        //Character(string name, int strenght, int damage, int health, int score)
        static Character CreateOpponent()
        {
            return new Character(
                InfoGen.NextFirstName(),
                InfoGen.Next(1, 9),
                InfoGen.Next(1,7),
                InfoGen.Next(1,9),
                0
                );
        }

        // Generate random number
        static int GenerateRandomNumber(int low, int high) // 
        {
            Random random = new Random();  // Get random cust
            int randomNumber = random.Next(low, high);
            return randomNumber;
        }

        // Ask for Input string
        static string AskUserForX(string x)
        {
            string input = "";

            while (input.Length == 0)
            {
                Console.WriteLine(x); //Ask for text with input string
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
                    Console.WriteLine("Not a number. Please try again.");
                }
            }

            return number;

        }

        // Messageline with color
        static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
            
        }
    }

    
}
