using System;
using System.Collections.Generic;
using System.Text;
using Lexicon.CSharp.InfoGenerator;

namespace ConsoleArenaFighterCharacter
{
    // for both the player and the opponents
    // int and string
    public class Character 
    {
        public string Name { get; set; }
        public int strenght;
        public int damage;
        public int health;


        public Character() { }
        public Character(string name, int strenght, int damage, int health)
        {

            Name = name;
            this.strenght = strenght;
            this.damage = damage;
            this.health = health;

            Console.Clear();
            DisplayCharacter(Name, strenght, damage, health);
            Console.ReadKey();
        }

        public Character(int strenght, int damage, int health)
        {

            Name = ""; // get random name of opponent
            this.strenght = strenght;
            this.damage = damage;
            this.health = health;

            Console.Clear();
            DisplayCharacter(Name, strenght, damage, health);
            Console.ReadKey();
        }

        //Console.WriteLine("Name: " + name);
        //Console.WriteLine("Strenght: " + GenerateRandomNumber(1, 9));
        //Console.WriteLine("Damage: " + GenerateRandomNumber(1, 9));
        //Console.WriteLine("Health: " + GenerateRandomNumber(1, 9));


        static void DisplayCharacter(string Name, int strenght, int damage, int health)
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Strenght: " + strenght);
            Console.WriteLine("Damage: " + damage);
            Console.WriteLine("Helth: " + health);
        }

        // Display message, optional with color
        static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}


