using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Game
    {
        static public Planet CurrentPlanet = new Planet();
       
        public void RunGame()
        {
            CurrentPlanet = Universe.Earth;
            Console.WriteLine($"{Universe.Earth.inhabitants}");
            Console.WriteLine($"{Equations.DistanceTo(Universe.ProximaCentauriB)}");
        }
    }
}
