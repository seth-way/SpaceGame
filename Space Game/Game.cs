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
            Actions.newOrLoadGame();
            Console.SetCursorPosition(0, 15);
            Console.WriteLine($"{CurrentPlanet.name}");
            Game.NewShip.currentFuel = 10000000000000;
            Actions.ChangePlanets(Universe.Gazorpazorp);
            Console.WriteLine($"{CurrentPlanet.name}");





        }
    }
}
