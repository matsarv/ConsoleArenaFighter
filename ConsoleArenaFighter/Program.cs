
using ConsoleArenaFighterCharacter;
using System;

namespace ConsoleArenaFighter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Character player = CreatePlayer();

 
            DisplayMessage(
            "\nWhat do you want to do?\n" +
            "H - Hunt for an opponent\n" +
            "R - Retire from fighting\n"
            );
            //string selection = AskUserForX(""); // keyInput
            char play = Console.ReadKey(true).KeyChar;
            switch (play)
            {
                case 'h':
                    Console.Clear();
                    Console.WriteLine("create opponent");
                    Console.WriteLine("start battle");
                    break;
                case 'r':
                    DisplayMessage("You have ended the violence by not fighting.");
                    Console.Clear();
                    Console.WriteLine("Final Statistics: \n");
                    Console.WriteLine("Name: " + player.Name);
                    /*
                    Console.WriteLine("Strenght: " + strenght);
                    Console.WriteLine("Damage: " + damage);
                    Console.WriteLine("Helth: " + health);
                    Console.WriteLine(name + "total score is " + "<score>" + "");
                    */
                    break;
                default:
                    break;
            }
            

            Console.ReadKey();
        }

        static Character CreatePlayer()
        {
            string name = AskUserForX("Enter the name of your character");
            int strenght = AskUserForNumberX("Enter strenght (between 1-9)");
            int damage = AskUserForNumberX("Enter damage (between 1-5)");
            int health = AskUserForNumberX("Enter strenght (between 1-9)");

            return new Character(name, strenght, damage, health);
            
        }


        // generate random number
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
