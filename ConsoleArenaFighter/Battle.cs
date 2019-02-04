using System;
using System.Collections.Generic;
using System.Text;
using Lexicon.CSharp.InfoGenerator;

namespace ConsoleArenaFighter

{
    /// <summary>
    /// For the battle itself; should contain the log of the battle, 
    /// as well as references to both the player and the opponent
    /// </summary>
    public class Battle
    {
        static InfoGenerator InfoGen = new InfoGenerator(DateTime.Now.Millisecond);

        public Character player { get; set; }
        public Character opponent { get; set; }
        
        public List<int> Score { get; set; }
        public List<Round> Rounds { get; set; }
        //public List<Battle> Battles { get; set; }

        char keyPress;
        
        // Constructor to get player from Battle.cs
        public Battle(Character player)
        {
            Rounds = new List<Round>();
            Score = new List<int>();

            this.player = player;
            Score.Add(0);
            
            bool keepAlive = true;
            int totalScore = 0;

            while (keepAlive)
            {
                Console.Clear();

                if (player.health > 0)
                {
                    if (Score.Count > 1) { Score.Add(5); }
                    player.DisplayCharacter();
                    Console.WriteLine();
                    Console.Write(
                    "What do you want to do?\n" +
                    "H - Hunt for an opponent\n" +
                    "R - Retire from fighting\n"
                    );
                    keyPress = Console.ReadKey(true).KeyChar;
                }

                if (player.health <= 0) { keyPress = 'r'; }

                switch (keyPress)
                {
                    case 'h':
                        Character opponent = CreateOpponent();

                        Console.Clear();
                        Console.WriteLine("\nPlayer:");

                        player.DisplayCharacter();

                        Console.WriteLine("\nOpponent:");

                        opponent.DisplayCharacter();

                        Console.ReadKey();

                        // Get score
                        Round round = new Round(player, opponent);
                        Rounds.Add(round);

                        

                        break;

                    case 'r':

                        if (player.health > 0)
                        {
                            Console.WriteLine("You have ended the violence by not fighting.");
                            Console.ReadKey();
                        }
                        else
                        {
                            
                            //player.health = "Dead"; 
                        }
                        foreach (var value in Score)
                        {
                            totalScore = totalScore + value;
                        }

                        Console.Clear();
                        Console.WriteLine("Final Statistics: \n");
                        player.DisplayCharacter();
                        Console.WriteLine(player.Name + " total score is " + totalScore + ".");
                        Console.ReadKey();
                        keepAlive = false;
                        break;

                    default:
                                               
                        break;
                }

            }
            Console.WriteLine("The End");
            Console.ReadKey();
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
