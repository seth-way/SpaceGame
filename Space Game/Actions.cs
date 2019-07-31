using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    public class Actions
    {
        //public void buyGoods
        //{

        //}

        //public void sellGoods
        //{

        //}

        static public void changePlanets(Planet destination)
        {
            double distance = Equations.DistanceTo(destination);
            double time = Equations.travelTime(distance);
            var fuelCost = Game.NewShip.fuelPerLightYear * distance;

            Game.NewShip.fuel = Game.NewShip.fuel - fuelCost;
            Game.NewPlayer.age = Game.NewPlayer.age + time;

            Game.CurrentPlanet = destination;

        }
    }
}
