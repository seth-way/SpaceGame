using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SpaceGame
{
    public class Actions
    {
        static double getIndexPrice(int index)
        {
            double price;
            if (index == 0)
            {
                price = Game.CurrentMarket.air;
                return price;
            }
            else if (index == 1)
            {
                price = Game.CurrentMarket.fur;
                return price;
            }
            else if (index == 2)
            {
                price = Game.CurrentMarket.robot;
                return price;
            }
            else if (index == 3)
            {
                price = Game.CurrentMarket.doors;
                return price;
            }
            else if (index == 4)
            {
                price = Game.CurrentMarket.seeds;
                return price;
            }
            else
            {
                price = 10;
                return price;
            }
        }

        static public void BuyFuel(int quantity, Planet CurrentPlanet)
        {
            double fuelPrice = UpdateFuelPrice(CurrentPlanet);
            if (fuelPrice * quantity <= Game.NewPlayer.wallet) // can afford fuel
            {
                Game.NewPlayer.wallet -= fuelPrice * quantity;
                Game.NewShip.currentFuel += quantity;
            }
            else
            {
                Console.Write($"Great, you can't afford fuel.\n" +
                    $"Good thing money isn't our entire goal out here./s");
            }
        }


        static public void BuyGoods(int index, int quantity, Planet CurrentPlanet)
        {
            UpdateMarketPrices(CurrentPlanet);
            double price = getIndexPrice(index);
            if (price * quantity <= Game.NewPlayer.wallet) //can afford item.
            {
                Game.NewPlayer.wallet -= price * quantity;
                Products.productList[index].onHand = Products.productList[index].onHand + quantity;
            }
            else //can not afford item.
            {
                Console.Write($"You can't afford that.\n" +
                    $"Maybe you should use one of those\n" +
                    $"Mega Tree Seeds, seems you could\n" +
                    $"use the boost."); 
            }

        }

        static public void SellGoods(int index, int quantity, Planet CurrentPlanet)
        {
            UpdateMarketPrices(CurrentPlanet);
            double price = getIndexPrice(index);
            if (quantity <= Products.productList[index].onHand) // have enough on hand to sell
            {
                Game.NewPlayer.wallet += price * quantity;
                Products.productList[index].onHand = Products.productList[index].onHand - quantity;
            }
            else //not enough on hand to sell
            {
                //Console.Write($"Stop trying to sell more than you have on hand.");
                Console.WriteLine("You don't have that many.\n" +
                    $"If things keep going this way\n" +
                    $"we'll have to sell you in\n" +
                    $"place of the Gazorpazorp robots.");
            }
        }

        static public bool ChangePlanets(Planet destination, Planet CurrentPlanet)
        {
            bool travelAble = true;
            if(destination == CurrentPlanet)
            {
                Console.WriteLine("You are already there. . . . .\n" +
                    " . . . . . . . . . . . . . . . \n" +
                    " . . . . . . . . . . . . . . . \n" +
                    " . . . . . . . . . . . . . . . \n" +
                    "What did I do to deserve to be\n" +
                    "stuck with you . . . . . . . . ");
                Console.ReadKey();
            }
            double distance = Equations.DistanceTo(destination, CurrentPlanet);
            double time = Equations.TravelTime(distance);
            var fuelCost = Game.NewShip.fuelPerLightYear * distance;

            if ((Game.NewShip.currentFuel - fuelCost) <= 0)
            {
                if (Game.NewShip.currentFuel == Game.NewShip.maxFuel)
                {
                    Console.WriteLine ("Do you not understand the concept of fuel?\n" +
                        "Or is it the idea of fuel capacity that seems to elude you?\n" +
                        "It's not like there's a universe of tiny people powering our ship.\n" +
                        "Upgrade and try again.");
                    Console.ReadKey ();
                }
                else
                {
                    Console.WriteLine ("Just like your crush left you on read,\n" +
                        "you've left the tank on empty.\n" +
                        "Fill it up and try again.\n\n" +
                        "Loser.");
                    Console.ReadKey ();
                }
                travelAble = false;
            }
            else
            {
                Game.NewShip.currentFuel -= fuelCost;
                Game.NewPlayer.age += time;

                bool gameWin = MiniGame.Minigame();
                if (gameWin == true)
                {
                    UpdateMarketPrices(CurrentPlanet);
                }
                else
                {
                    travelAble = false;
                }
            }
                return travelAble;

        }


        public static void UpdateMarketPrices(Planet CurrentPlanet)
        {
            if (CurrentPlanet == Universe.Earth)
            {
                Game.CurrentMarket = Products.earthPrices;
            }
            else if (CurrentPlanet == Universe.ProximaCentauriB)
            {
                Game.CurrentMarket = Products.proximaPrices;
            }
            else if (CurrentPlanet == Universe.Gazorpazorp)
            {
                Game.CurrentMarket = Products.gazorpazorpPrices;
            }
            else if (CurrentPlanet == Universe.C35)
            {
                Game.CurrentMarket = Products.c35Prices;
            }
            else if (CurrentPlanet == Universe.GromflomPrime)
            {
                Game.CurrentMarket = Products.gromflomPrices;
            }
            else
            {
                Game.CurrentMarket = new Market()
                {
                    air = 0.00,
                    fur = 0.00,
                    robot = 0.00,
                    doors = 0.00,
                    seeds = 0.00
                };
            }
            UpdateFuelPrice(CurrentPlanet);
        }

        public static double UpdateFuelPrice(Planet CurrentPlanet)
        {
            double currentPrice = CurrentPlanet.dangerRating * 1; // modifier may require tweaking
            return currentPrice;
        }

        public static void LoadGame(Planet CurrentPlanet)
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
            Game.NewShip.currentFuel = double.Parse(tr.ReadLine());
            Game.NewShip.fuelPerLightYear = double.Parse(tr.ReadLine());
            Game.NewShip.currentInventory = int.Parse(tr.ReadLine());
            Game.NewShip.maxInventory = int.Parse(tr.ReadLine());
            Products.CannedAir.onHand = int.Parse(tr.ReadLine());
            Products.CentaurianFur.onHand = int.Parse(tr.ReadLine());
            Products.ServiceRobot.onHand = int.Parse(tr.ReadLine());
            Products.RealFakeDoors.onHand = int.Parse(tr.ReadLine());
            Products.MegaTreeSeeds.onHand = int.Parse(tr.ReadLine());
            CurrentPlanet = Universe.planetTravel[int.Parse(tr.ReadLine())];

            tr.Close();

            //Game.CurrentPlanet = Universe.thisPlanet;    not possible... but need to set current planet somehow?
        }

        public static void SaveGame(Planet CurrentPlanet)
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
            tw.WriteLine(Game.NewShip.currentFuel);
            tw.WriteLine(Game.NewShip.fuelPerLightYear);
            tw.WriteLine(Game.NewShip.currentInventory);
            tw.WriteLine(Game.NewShip.maxInventory);
            tw.WriteLine(Products.CannedAir.onHand);
            tw.WriteLine(Products.CentaurianFur.onHand);
            tw.WriteLine(Products.ServiceRobot.onHand);
            tw.WriteLine(Products.RealFakeDoors.onHand);
            tw.WriteLine(Products.MegaTreeSeeds.onHand);
            tw.Write(Array.IndexOf(Universe.planetTravel, CurrentPlanet));

            tw.Close();
        }
    }
}
