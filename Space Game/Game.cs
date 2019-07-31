using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Game
    {
        Universe GameUniverse = new Universe();
        static public Planet CurrentPlanet = new Planet();
       
        public void RunGame()
        {
            CurrentPlanet = GameUniverse.Earth;
            Console.WriteLine($"{GameUniverse.Earth.Inhabitants()}");
            Console.WriteLine($"{Equations.DistanceTo(GameUniverse.ProximaCentauriB)}");
        }

        
    }
}
