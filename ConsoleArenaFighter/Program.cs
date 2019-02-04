
//using ConsoleArenaFighterCharacter;
using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;

namespace ConsoleArenaFighter
{
    class Program
    {
        static InfoGenerator InfoGen = new InfoGenerator(DateTime.Now.Millisecond);

        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.White;
            //List<Character> playerCharacter = new List<Character>(); //Not needed

            // Player enter Character
            string name = AskUserForX("Enter the name of your character");
            int strenght = AskUserForNumberX("Enter strenght (between 1-9)");
            int damage = AskUserForNumberX("Enter damage (between 1-5)");
            int health = AskUserForNumberX("Enter strenght (between 1-9)");
            Character player = new Character(name,strenght,damage,health);

            // Start battle class with Player input 
            Battle battle = new Battle(player);

        }

        /// <summary>
        /// Ask user for input string
        /// </summary>
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

        /// <summary>
        /// Ask user for input numberm handle exeptions
        /// </summary>
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
