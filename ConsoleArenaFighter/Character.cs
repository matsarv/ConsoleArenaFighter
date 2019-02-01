using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleArenaFighter
{
    // for both the player and the opponents
    public class Character 
    {
        // Properties
        public string Name { get; set; }
        public int strenght;
        public int damage;
        public int health;  //  { get; set; } // 0 eller -1 dead

        // Default constructor
        public Character() { }
        // Instance constructor with four parameters
        public Character(string name, int strenght, int damage, int health)
        {
            Name = name;
            this.strenght = strenght;
            this.damage = damage;
            this.health = health;
        }

        // Constructor to print player or opponent ex. player.DisplayCharacter();
        public void DisplayCharacter()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Strenght: " + strenght);
            Console.WriteLine("Damage: " + damage);
            Console.WriteLine("Helth: " + health);
        }

    }
}


