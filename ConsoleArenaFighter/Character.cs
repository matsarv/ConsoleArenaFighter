using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleArenaFighter
{
    /// <summary>
    ///    Class for both player and opponents
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Properties
        /// </summary>
        public string Name { get; set; }
        public int strenght;
        public int damage;
        public int health;  //  { get; set; } // 0 eller -1 dead
        public List<int> Score { get; set; }
        public List<string> Battles { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Character() { }

        /// <summary>
        /// Instance Constructor with four input parameters
        /// </summary>
        public Character(string name, int strenght, int damage, int health)
        {
            Name = name;
            this.strenght = strenght;
            this.damage = damage;
            this.health = health;
            Score = new List<int>();
            Battles = new List<string>();
        }

        /// <summary>
        /// Constructor to print player or opponent
        /// </summary>
        public void DisplayCharacter()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Strenght: " + strenght);
            Console.WriteLine("Damage: " + damage);
            Console.WriteLine("Healt: " + ((health <= 0) ? "Dead" : health.ToString()));
        }
    }
}


