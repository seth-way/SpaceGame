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
        static public Planet CurrentPlanet = new Planet();
        static public Player NewPlayer = new Player();
        static public Ship NewShip = new Ship();
        static public Market CurrentMarket = new Market();
       
        public void RunGame()
        {
            CurrentPlanet = Universe.Earth;
            UserMenu ();
            MenuSelection();
            
        }
    }
}
