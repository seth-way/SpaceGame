using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Game
    {
        Products GameProducts = new Products ();
        public Planet TempPlanet = new Planet();
        public void RunGame()
        {
            Console.WriteLine($"{Universe.Earth.Inhabitants()}");
            Console.WriteLine (GameProducts.CentaurianFur.name);
        }
    }
}



// Helper.Collision