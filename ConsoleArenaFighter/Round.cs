using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleArenaFighter
{
    /// <summary>
    /// Class to play battle Roud
    /// </summary>
    public class Round
    {
        public Round(Character player, Character opponent)
        {
            bool throwDice = true;
            int score = 0;

            do
            {
                int playerDiceRoll = DiceRoll(1, 9);
                int newPlayerStrenght = player.strenght + playerDiceRoll;

                int opponentDiceRoll = DiceRoll(1, 9);
                int newOpponentStrenght = opponent.strenght + opponentDiceRoll;

                Console.WriteLine();
                Console.WriteLine("-----------------------");
                Console.WriteLine(
                    "Rolls: " +
                    player.Name + " " + newPlayerStrenght + " (" + player.strenght + "+" + playerDiceRoll + ")" +
                    " vs " +
                    opponent.Name + " " + newOpponentStrenght + " (" + opponent.strenght + "+" + opponentDiceRoll + ")"
                    );

                if (newPlayerStrenght == newOpponentStrenght)
                {
                    Console.WriteLine("Evenly matched, the combatants circle each other, looking for a better opportunity.");
                    Console.WriteLine("Remaining Health: " + player.Name + " (" + player.health + "), " + opponent.Name + " (" + opponent.health + ")");
                }

                else if (newPlayerStrenght > newOpponentStrenght)
                {
                    opponent.health = opponent.health - player.damage;
                    WriteColorLine(
                        player.Name + " attacks " + opponent.Name + "! " + opponent.Name + " takes " + player.damage + " damage.",
                        ConsoleColor.Green
                        );

                    /// <summary>
                    /// Player is victorious!
                    /// </summary>
                    if (opponent.health <= 0)
                    {
                        Console.WriteLine(
                            "Remaining Health: " +
                            player.Name + " (" + player.health + "), " + opponent.Name + " (Dead)\n" +
                            "\n-----------------------\n" +
                            player.Name + " is victorious!"
                            );

                        score = score + 5;
                        player.Score.Add(score);
                        player.Battles.Add(player.Name + " fought and killed " + opponent.Name + ".");

                        Console.ReadKey();

                        throwDice = false;
                    }
                    else
                    {
                        Console.WriteLine(
                            "Remaining Health: " + player.Name + " (" + player.health + "), " + opponent.Name + " (" + opponent.health + ")");
                    }
                }
                else
                {
                    player.health = player.health - opponent.damage;
                    WriteColorLine(
                        opponent.Name + " attacks " + player.Name + "! " + player.Name + " takes " + opponent.damage + " damage.",
                        ConsoleColor.Red
                        );

                    /// <summary>
                    /// Opponent is victorious!
                    /// </summary>
                    if (player.health <= 0)
                    {
                        Console.WriteLine(
                            "Remaining Health: " +
                            player.Name + " (Dead). " + opponent.Name + " (" + opponent.health + ")\n" +
                            "\n-----------------------\n" +
                            opponent.Name + " is victorious!"
                            );

                        score = score + 2;
                        player.Score.Add(score);
                        player.Battles.Add(player.Name + " was killed by " + opponent.Name + ".");

                        Console.ReadKey();

                        throwDice = false;
                    }
                    else
                    {
                        Console.WriteLine("Remaining Health: " + player.Name + " (" + player.health + "). " + opponent.Name + " (" + opponent.health + ")");
                    }
                }

            } while (throwDice);

            return;
        }

        /// <summary>
        /// Generate random Dice number
        /// </summary>
        static int DiceRoll(int low, int high) // 
        {
            Random random = new Random();  // Get random cust
            int randomNumber = random.Next(low, high);
            return randomNumber;
        }

        /// <summary>
        /// Display message line with color
        /// </summary>
        static void WriteColorLine(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();

        }
    }
}
