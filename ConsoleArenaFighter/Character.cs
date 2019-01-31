using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleArenaFighter
{
    // for both the player and the opponents
    // int and string
    public class Character 
    {
        public string Name { get; set; }
        public int strenght;
        public int damage;
        public int health;
        public int score;

        public Character() { }
        public Character(string name, int strenght, int damage, int health, int score)
        {
            Name = name;
            this.strenght = strenght;
            this.damage = damage;
            this.health = health;
            this.score = score;
        }

        // use to display ex. player.DisplayCharacter();
        public void DisplayCharacter()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Strenght: " + strenght);
            Console.WriteLine("Damage: " + damage);
            Console.WriteLine("Helth: " + health);
        }

    }
}


