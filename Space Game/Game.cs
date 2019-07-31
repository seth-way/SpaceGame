using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Game
    {
        Universe GameUniverse = new Universe();
        public Planet TempPlanet = new Planet();
        public void RunGame()
        {
            Console.WriteLine($"{GameUniverse.Earth.Inhabitants()}");


        }
    }
}
