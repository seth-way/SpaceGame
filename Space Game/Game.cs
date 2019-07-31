using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
