using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    public class Actions
    {
        //public void buyGoods(
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

        static public void calculatePrices()
        {
            double priceAir = Products.CannedAir.price * Equations.DistanceTo(Products.CannedAir.originPlanet) * Game.CurrentPlanet.dangerRating;
            double priceFur = Products.CentaurianFur.price * Equations.DistanceTo(Products.CentaurianFur.originPlanet) * Game.CurrentPlanet.dangerRating;
            double priceRobot = Products.ServiceRobot.price * Equations.DistanceTo(Products.ServiceRobot.originPlanet) * Game.CurrentPlanet.dangerRating;
            double priceDoor = Products.RealFakeDoors.price * Equations.DistanceTo(Products.RealFakeDoors.originPlanet) * Game.CurrentPlanet.dangerRating;
            double priceSeed = Products.MegaTreeSeeds.price * Equations.DistanceTo(Products.MegaTreeSeeds.originPlanet) * Game.CurrentPlanet.dangerRating;

            //for testing
            Console.WriteLine($"air | {priceAir} - fur | {priceFur} - robot | {priceRobot} - door | {priceDoor} - seed | {priceSeed}\n");
        }
    }
}
