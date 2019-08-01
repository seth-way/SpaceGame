using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    public class Actions
    {


        static public void buyGoods(int index, int quantity)
        {
            List<double> priceList = UpdateMarketPrices();
            if (priceList[index] * quantity <= Game.NewPlayer.wallet) //can afford item.
            {
                Game.NewPlayer.wallet = Game.NewPlayer.wallet - priceList[index] * quantity;
                Products.productList[index].onHand = Products.productList[index].onHand + quantity;
            }
            else //can not afford item.
            {
                Console.Write($"You can't afford that.");
            }

        }

        static public void sellGoods(int index, int quantity)
        {
            List<double> priceList = UpdateMarketPrices();
            if (quantity <= Products.productList[index].onHand) // have enough to sell
            {
                Game.NewPlayer.wallet = Game.NewPlayer.wallet + priceList[index] * quantity;
                Products.productList[index].onHand = Products.productList[index].onHand - quantity;
            }
            else //not enough on hand to sell
            {
                Console.Write($"Stop trying to sell more than you have on hand.");
            }
        }

        static public void changePlanets(Planet destination)
        {
            double distance = Equations.DistanceTo(destination);
            double time = Equations.travelTime(distance);
            var fuelCost = Game.NewShip.fuelPerLightYear * distance;

            Game.NewShip.fuel = Game.NewShip.fuel - fuelCost;
            Game.NewPlayer.age = Game.NewPlayer.age + time;

            Game.CurrentPlanet = destination;

        }

        
        public static List<double> UpdateMarketPrices()
        {
            List<double> currentPrices = new List<double>();

            currentPrices[0] = Products.CannedAir.price * (1 + Equations.DistanceTo(Products.CannedAir.originPlanet)) * Game.CurrentPlanet.dangerRating;
            currentPrices[1] = Products.CentaurianFur.price * (1 + Equations.DistanceTo(Products.CentaurianFur.originPlanet)) * Game.CurrentPlanet.dangerRating;
            currentPrices[2] = Products.ServiceRobot.price * (1 + Equations.DistanceTo(Products.ServiceRobot.originPlanet)) * Game.CurrentPlanet.dangerRating;
            currentPrices[3] = Products.RealFakeDoors.price * (1 + Equations.DistanceTo(Products.RealFakeDoors.originPlanet)) * Game.CurrentPlanet.dangerRating;
            currentPrices[4] = Products.MegaTreeSeeds.price * (1 + Equations.DistanceTo(Products.MegaTreeSeeds.originPlanet)) * Game.CurrentPlanet.dangerRating;
            
            return currentPrices;
        }

        public class Prices
        {
            double priceAir, priceFur, priceRobot, priceDoor, priceSeed;
        }
    }
}
