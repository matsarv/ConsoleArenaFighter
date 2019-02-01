using System;
using System.Collections.Generic;
using System.Text;
using Lexicon.CSharp.InfoGenerator;

namespace ConsoleArenaFighter

{

    // for the battle itself; should contain the log of the battle, 
    // as well as references to both the player and the opponent
    public class Battle
    {
        static InfoGenerator InfoGen = new InfoGenerator(DateTime.Now.Millisecond);

        public Character player { get; set; }
        public Character opponent { get; set; }




        //public Battle() { }
        // Constructor to get player from Program.cs
        public Battle(Character player)
        {
            this.player = player;


            

            // Loop if win
            
            Console.Clear();
            player.DisplayCharacter();

            Console.WriteLine();
            Console.Write(
            "What do you want to do?\n" +
            "H - Hunt for an opponent\n" +
            "R - Retire from fighting\n"
            );
            //string selection = AskUserForX(""); // keyInput
            char play = Console.ReadKey(true).KeyChar;

            switch (play)
            {
                case 'h':
                    Character opponent = CreateOpponent();
                    Console.Clear();

                    Console.WriteLine("\nPlayer:");
                    player.DisplayCharacter();

                    Console.WriteLine("\nOpponent:");
                    opponent.DisplayCharacter();

                    Console.ReadKey();

                    Console.WriteLine("start battle - Round.cs");

                    break;

                case 'r':
                    Console.WriteLine("You have ended the violence by not fighting.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Final Statistics: \n");
                    player.DisplayCharacter();
                    Console.WriteLine(player.Name + " total score is " + "player.score" + ".");
                    break;

                default:
                    Console.WriteLine("switch default");
                    //Console.Clear();
                    //Console.WriteLine("Final Statistics: \n");
                    //player.DisplayCharacter();
                    //Console.WriteLine(player.Name + " total score is " + "player.score" + ".");
                    break;
            }


            Console.ReadKey();


        }

        // Constructor to get player
        // Character(string name, int strenght, int damage, int health, int score)
        private static Character CreatePlayer(string name, int strenght, int damage, int health)
        {
            return new Character(
                name,
                strenght,
                damage,
                health
                );
        }

        // Constructor to get opponent
        // Character(string name, int strenght, int damage, int health, int score)
        private static Character CreateOpponent()
        {
            return new Character(
                InfoGen.NextFirstName(),
                InfoGen.Next(1, 9),
                InfoGen.Next(1, 7),
                InfoGen.Next(1, 9)
                );
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
    }
}
