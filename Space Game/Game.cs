using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    public class Game
    {
        static Universe GameUniverse = new Universe();
        Planet TempPlanet = new Planet();
        TempPlanet = GameUniverse.Earth();
        public void RunGame()
        {
            Console.WriteLine($"{TempPlanet.Inhabitants()}");

            Console.WriteLine($"{GameUniverse.Earth.Inhabitants()}");
        }
    }
}
