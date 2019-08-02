using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SpaceGame
{
    public class Actions
    {
        static public void buyFuel(int quantity)
        {
            double fuelPrice = UpdateFuelPrice();
            if (fuelPrice * quantity <= Game.NewPlayer.wallet) // can afford fuel
            {
                Game.NewPlayer.wallet = Game.NewPlayer.wallet - fuelPrice * quantity;
                Game.NewShip.fuel = Game.NewShip.fuel + quantity;
            }
            else
            {
                Console.Write($"You can't afford that.");
            }
        }


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
            if (quantity <= Products.productList[index].onHand) // have enough on hand to sell
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

        public static double UpdateFuelPrice()
        {
            double currentPrice = Game.CurrentPlanet.dangerRating * 1; // modifier may require tweaking
            return currentPrice;
        }

        public static void LoadGame()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            int bin = currentDirectory.IndexOf("bin");
            currentDirectory = currentDirectory.Substring(0, bin) + "assets/savedgame.txt";

            TextReader tr = new StreamReader(currentDirectory);

            Game.NewPlayer.name = tr.ReadLine();
            Game.NewPlayer.age = double.Parse(tr.ReadLine());
            Game.NewPlayer.wallet = double.Parse(tr.ReadLine());
            Game.NewShip.name = tr.ReadLine();
            Game.NewShip.warpFactor = int.Parse(tr.ReadLine());
            Game.NewShip.fuel = double.Parse(tr.ReadLine());
            Game.NewShip.fuelPerLightYear = double.Parse(tr.ReadLine());
            Game.NewShip.storageCapacity = int.Parse(tr.ReadLine());
            Products.CannedAir.onHand = int.Parse(tr.ReadLine());
            Products.CentaurianFur.onHand = int.Parse(tr.ReadLine());
            Products.ServiceRobot.onHand = int.Parse(tr.ReadLine());
            Products.RealFakeDoors.onHand = int.Parse(tr.ReadLine());
            Products.MegaTreeSeeds.onHand = int.Parse(tr.ReadLine());
            string thisPlanet = tr.ReadLine();

            tr.Close();

            //Game.CurrentPlanet = Universe.thisPlanet;    not possible... but need to set current planet somehow?
        }

        public static void SaveGame()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            int bin = currentDirectory.IndexOf("bin");
            currentDirectory = currentDirectory.Substring(0, bin) + "assets/savedgame.txt";

            File.Create(currentDirectory).Close(); //clears text file
            
            TextWriter tw = new StreamWriter(currentDirectory);
            tw.WriteLine(Game.NewPlayer.name);
            tw.WriteLine(Game.NewPlayer.age);
            tw.WriteLine(Game.NewPlayer.wallet);
            tw.WriteLine(Game.NewShip.name);
            tw.WriteLine(Game.NewShip.warpFactor);
            tw.WriteLine(Game.NewShip.fuel);
            tw.WriteLine(Game.NewShip.fuelPerLightYear);
            tw.WriteLine(Game.NewShip.storageCapacity);
            tw.WriteLine(Products.CannedAir.onHand);
            tw.WriteLine(Products.CentaurianFur.onHand);
            tw.WriteLine(Products.ServiceRobot.onHand);
            tw.WriteLine(Products.RealFakeDoors.onHand);
            tw.WriteLine(Products.MegaTreeSeeds.onHand);
            tw.Write(Game.CurrentPlanet.name);

            tw.Close();
        }
    }
}
