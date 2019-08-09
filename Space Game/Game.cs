using System;
using System.Collections.Generic;
using System.Text;
using static SpaceGame.StoryLine;
using static SpaceGame.Draw;
using static SpaceGame.UI;

namespace SpaceGame
{
    class Game
    {
        static public Player NewPlayer = new Player();
        static public Ship NewShip = new Ship();
        static public Market CurrentMarket = new Market();
       
        public void RunGame()
        {
            Planet StartPlanet = Actions.newOrLoadGame ();
            Console.WriteLine ("What is your name?");
            string name = Console.ReadLine ();
            Console.Title = name + ": A Life Well Lived";
            NewPlayer.wallet = 1000000;
            //NewPlayer.age = 60;
            MenuSelection (StartPlanet);
            
        }
    }
}
