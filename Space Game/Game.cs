using System;
using System.Collections.Generic;
using System.Text;
using static SpaceGame.StoryLine;
using static SpaceGame.Draw;

namespace SpaceGame
{
    class Game
    {
        static public Planet CurrentPlanet = new Planet();
        static public Player NewPlayer = new Player();
        static public Ship NewShip = new Ship();
       
        public void RunGame()
        {
            
            CurrentPlanet = Universe.Earth;
            Console.WriteLine($"{CurrentPlanet.inhabitants}\nfuel | {NewShip.fuel}\nage | {NewPlayer.age}\n");
            Actions.changePlanets(Universe.ProximaCentauriB);
            Console.WriteLine($"{CurrentPlanet.inhabitants}\nfuel | {NewShip.fuel}\nage | {NewPlayer.age}");
            //checks distance equation.
            //Console.WriteLine($"It will take {Equations.travelTime(Equations.DistanceTo(Universe.C35))} years to get to U35");
            //checks travel time equation.
            //DrawImage(file name from assets folder(must be a .bmp file type), int x cursor position(default is 160), int image size); added in an adjustable size for the image and x position to the code, need to add in y position
            DrawImage("SDA_pg41.bmp");
            TextOutput(introStory_1);
        }
    }
}
