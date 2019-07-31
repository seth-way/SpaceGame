using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Game
    {
        static public Planet CurrentPlanet = new Planet();
        static public Player NewPlayer = new Player();
       
        public void RunGame()
        {
            CurrentPlanet = Universe.Earth;
            Console.WriteLine($"{Universe.Earth.inhabitants}");
            Console.WriteLine($"{Equations.DistanceTo(Universe.ProximaCentauriB)}");
            //checks distance equation.
            Console.WriteLine($"It will take {Equations.travelTime(Equations.DistanceTo(Universe.C35))} years to get to U35");
            //checks travel time equation.

            Class1.TextOutput (Class1.story);

        }
    }
}
