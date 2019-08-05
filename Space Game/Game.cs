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
       
        public void RunGame()
        {
            //CurrentPlanet = Universe.Earth;
            //Console.WriteLine($"{CurrentPlanet.inhabitants}\nfuel | {NewShip.currentFuel}\nage | {NewPlayer.age}\n");
            ////Actions.UpdateMarketPrices();
            //Actions.changePlanets(Universe.ProximaCentauriB);
            //Console.WriteLine($"{CurrentPlanet.inhabitants}\nfuel | {NewShip.currentFuel}\nage | {NewPlayer.age}\n");
            ////Actions.UpdateMarketPrices();
            //Actions.SaveGame();
            //checks distance equation.
            //Console.WriteLine($"It will take {Equations.travelTime(Equations.DistanceTo(Universe.C35))} years to get to U35");
            //checks travel time equation.
            ////////DrawImage(file name from assets folder(must be a .bmp file type), int x image position, int y image position, int image size); 
            //DrawImage ("SDA_pg41.bmp", imageYPosition: (Console.WindowHeight / 2));
            //TextOutput (introStory_1);
            //UserMenu ();
            //TravelMenu ();
            MiniGame.PirateGame();
        }
    }
}
