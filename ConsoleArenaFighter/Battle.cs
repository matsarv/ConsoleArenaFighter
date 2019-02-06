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

        readonly char keyPress;

        public Character Player { get; set; }
        public Character Opponent { get; set; }

        public List<int> Score { get; set; }
        public List<Round> Rounds { get; set; }
        public List<Battle> Battles { get; set; }

        /// <summary>
        /// Constructor to get player from Battle.cs
        /// </summary>
        public Battle(Character player)
        {
            bool keepAlive = true;
            int totalScore = 0;

            Rounds = new List<Round>();

            this.Player = player;
            player.Score.Add(0);

            while (keepAlive)
            {
                Console.Clear();

                if (player.health > 0)
                {
                    player.DisplayCharacter();

                    Console.Write(
                    "\nWhat do you want to do?\n" +
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

                        /// <summary>
                        /// Start a new Round
                        /// </summary>
                        Round round = new Round(player, opponent);
                        Rounds.Add(round);

                        break;

                    case 'r':

                        if (player.health > 0)
                        {
                            Console.WriteLine("You have ended the violence by not fighting.");
                            Console.ReadKey();
                        }

                        foreach (var value in player.Score)
                        {
                            totalScore = totalScore + value;
                        }

                        Console.Clear();
                        Console.WriteLine("Final Statistics: \n");

                        player.DisplayCharacter();

                        foreach (string value in player.Battles)
                        {
                            Console.WriteLine(value);
                        }

                        Console.WriteLine(player.Name + " total score is " + totalScore + ".");

                        Console.ReadKey();

                        keepAlive = false;
                        break;

                    default:

                        break;
                }
            }
        }

        /// <summary>
        /// Constructor to get opponent, Character(string name, int strenght, int damage, int health)
        /// </summary>
        private static Character CreateOpponent()
        {
            return new Character(
                InfoGen.NextFirstName(),
                InfoGen.Next(1, 9),
                InfoGen.Next(1, 7),
                InfoGen.Next(1, 9)
                );
        }
    }
}
