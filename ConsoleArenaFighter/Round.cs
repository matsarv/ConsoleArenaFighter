using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleArenaFighter
{
    // one round of dice rolling; should correspond to a post in the battle log
    public class Round
    {
        // generate random number
        public Round() { }
        public Round(int high)
        {
            Random random = new Random();  // Get random cust
            int randomStrenght = random.Next(1, high);
            int randomDamage = random.Next(1, high);
            int randomHealth = random.Next(1, high);

            //return ;
        }
        

    }
}
