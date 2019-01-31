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

        //create or load opponent        
           
        //Character opponent = CreateOpponent();

        //opponent
        
        //show player and opponent
        

        // start battle

        // use round for each dice Round.cs






        //Character(string name, int strenght, int damage, int health, int score)
        private static Character CreateOpponent()
        {
            return new Character(
                InfoGen.NextFirstName(),
                InfoGen.Next(1, 9),
                InfoGen.Next(1, 7),
                InfoGen.Next(1, 9),
                0
                );
        }
    }


}
