using System;
using System.Collections.Generic;
using static SpaceGame.Game;
using static SpaceGame.Universe;

namespace SpaceGame
{
    public static class UI
    {
        public static int currentSelection = 0;

        public static void UserMenu(Planet CurrentPlanet)
        {
            int i = Console.CursorTop;
            string menu = "|    F1 - Your Statistics        F2 - Ship Inventory         F3 - Trade/Upgrades        F4 - Travel        F5 - Save        F12 - Exit Game    |";
            string line = "-";
            string menu2 = $"|  Galactic Federation Credits: {NewPlayer.wallet}  |  Fuel: {NewShip.currentFuel}/{NewShip.maxFuel}  |  Age: {NewPlayer.age}  |  Year: {NewPlayer.currentYear}  |  InvSpace: {NewShip.currentInventory}/{NewShip.maxInventory}  |  Current Planet: {CurrentPlanet.name}  |";

            if (i == 0)
            {

                Console.ForegroundColor = ConsoleColor.DarkRed;
                for (int r = 0; r < Console.BufferWidth; r++)
                {
                    Console.SetCursorPosition(r, 0);
                    Console.Write(line);

                }
                Console.SetCursorPosition((((Console.BufferWidth) - menu.Length) / 2), 1);
                Console.Write(menu);
            }

            for (int r = 0; r < Console.BufferWidth; r++)
            {
                Console.SetCursorPosition(r, 2);
                Console.Write(line);
            }

            for (int r = 0; r < Console.BufferWidth; r++)
            {
                Console.SetCursorPosition(r, (Console.BufferHeight - 3));
                Console.Write(line);

            }
            Console.SetCursorPosition((Console.BufferWidth - menu2.Length) / 2, Console.BufferHeight - 2);
            Console.Write(menu2);
            for (int r = 0; r < Console.BufferWidth; r++)
            {
                Console.SetCursorPosition(r, (Console.BufferHeight - 1));
                Console.Write(line);

            }
            Console.SetCursorPosition(Console.CursorLeft, 6);   //is this necessary? YES. YES IT IS.

        }

        public static void MenuSelection(Planet loadPlanet)
        {
            Planet CurrentPlanet = loadPlanet;
            bool gameFinish = false;
            do
            {
                gameFinish = StoryLine.StoryCheck(NewShip.warpFactor, CurrentPlanet, gameFinish);
                Console.Clear();
                UserMenu(CurrentPlanet);
                ConsoleKey rKey = Console.ReadKey().Key;
                switch (rKey)
                {
                    case ConsoleKey.F1:
                        PlayerStatsMenu();
                        break;

                    case ConsoleKey.F2:
                        ShipStatsMenu();
                        break;

                    case ConsoleKey.F3:
                        TradeUpgradesMenu(CurrentPlanet);
                        break;

                    case ConsoleKey.F4:
                        CurrentPlanet = TravelMenu(CurrentPlanet);
                        break;

                    case ConsoleKey.F5:
                        Actions.SaveGame(CurrentPlanet);
                        break;

                    case ConsoleKey.F12:
                        Actions.SaveGame(CurrentPlanet);
                        Console.WriteLine("GoodBye");
                        Console.Beep();
                        gameFinish = true;
                        break;
                }
            } while (gameFinish == false);
        }

        public static void ShipStatsMenu()
        {
            // ship image here
            Console.SetCursorPosition(Console.CursorLeft, 6);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("Ship Name: " + NewShip.name);
            Console.WriteLine();
            Console.WriteLine("Warp Factor: " + NewShip.warpFactor);
            Console.WriteLine();
            Console.WriteLine($"Fuel: {NewShip.currentFuel}/{NewShip.maxFuel}");
            Console.WriteLine();
            Console.WriteLine($"Fuel Per Lightyear: {NewShip.fuelPerLightYear}");
            Console.WriteLine();
            Console.WriteLine($"Inventory: {NewShip.currentInventory}/{NewShip.maxInventory}");
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Can(s) of Earth Air: {Products.CannedAir.onHand}");
            Console.WriteLine();
            Console.WriteLine($"Centaurian Fur Pelt(s): {Products.CentaurianFur.onHand}");
            Console.WriteLine();
            Console.WriteLine($"Gazorpian Service Robot(s): {Products.ServiceRobot.onHand}");
            Console.WriteLine();
            Console.WriteLine($"Real Fake Door(s): {Products.RealFakeDoors.onHand}");
            Console.WriteLine();
            Console.WriteLine($"Mega Tree Seed(s): {Products.MegaTreeSeeds.onHand}");
            Console.ReadKey();
        }

        public static void PlayerStatsMenu()
        {
            Console.SetCursorPosition(Console.CursorLeft, 6);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Your Name: " + NewPlayer.name);
            Console.WriteLine();
            Console.WriteLine("Your Age: " + NewPlayer.age);
            Console.WriteLine();
            Console.WriteLine("Galactic Federation Credits: " + NewPlayer.wallet);
            Console.WriteLine();
            Console.WriteLine("Total Products Sold: " + NewPlayer.numOfProductsSold);
            Console.WriteLine();
            Console.WriteLine("Total Distance Traveled: " + NewPlayer.totalDistanceTraveled);
            Console.WriteLine();
            Console.WriteLine("Total Galactic Credits Earned: " + NewPlayer.totalMoneyEarned);
            Console.WriteLine();
            Console.WriteLine("Total Galactic Credits Stolen By Pirates: " + NewPlayer.totalMoneyStolen);
            Console.WriteLine();
            Console.WriteLine("Number Of Pirates Killed: " + NewPlayer.totalPiratesThwarted);
            Console.WriteLine();
            Console.WriteLine("Total Pirate Attacks Stopped: " + NewPlayer.totalPassedPirateAttacks);
            Console.WriteLine();
            Console.WriteLine("Total Pirate Attacks Failed: " + NewPlayer.totalFailedPirateAttacks);
            Console.ReadKey();
        }

        public static void TradeUpgradesMenu(Planet CurrentPlanet)
        {
            int selected = 0;

            bool finished = false;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string upgradeQuestion1 = "Use the UP and DOWN arrow keys to select an option" +
                ", then press enter.";
            string upgradeQuestion2 = "Press ESC to cancel";

            Console.SetCursorPosition((Console.WindowWidth - upgradeQuestion1.Length) / 2, 6);
            Console.WriteLine(upgradeQuestion1);
            Console.SetCursorPosition((Console.WindowWidth - upgradeQuestion2.Length) / 2, 7);
            Console.WriteLine(upgradeQuestion2);

            List<string> goodsOrShip = new List<string>() { "Goods", "Ship" };
            (finished, selected) = ListNavigation.scrollList(goodsOrShip, 9, finished);

            if (selected == 0 && finished != true)
            {
                TradeMenu(CurrentPlanet);
            }
            else if (selected == 1 && finished != true)
            {
                ShipUpgradesMenu(CurrentPlanet);
            }
            else
            {
                UserMenu(CurrentPlanet);
            }
        }

        public static void ShipUpgradesMenu(Planet CurrentPlanet)
        {

            int selected = 0;
            bool finished = false;

            List<double> upgradePrices = new List<double>()
            {
                 Math.Round(Actions.UpdateFuelPrice(CurrentPlanet), 2),
                 Equations.UpgradeCost(NewShip.fuelFactor),
                 Equations.UpgradeCost(NewShip.fuelEfficiencyFactor),
                 Equations.UpgradeCost(NewShip.storageFactor),
                 Equations.UpgradeCost(NewShip.warpFactor)
            };

            List<string> upgradeStrings = new List<string>()
            {
                 $"Purchase Fuel: #{upgradePrices[0]}",
                 $"Increase Fuel Capacity: #{upgradePrices[1]}",
                 $"Increase Fuel Efficiency: #{upgradePrices[2]}",
                 $"Increase Storage Capacity: #{upgradePrices[3]}",
                 $"Increase Warp Factor: #{upgradePrices[4]}"
            };

            List<string> toBuyStrings = new List<string>()
            {
                "more fuel",
                "a larger fuel tank",
                "better fuel efficiency",
                "more inventory space",
                "a faster Warp Factor"
            };

            List<double> upgradeAdds = new List<double>()
            {
                0,
                250,
                10,
                10,
                1
            };

            Console.Clear();
            UserMenu(CurrentPlanet);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string upgradeQuestion1 = "Use the UP and DOWN arrow keys to select a ship upgrade " +
                ", then press enter.";
            string upgradeQuestion2 = "Press ESC to cancel";

            Console.SetCursorPosition((Console.WindowWidth - upgradeQuestion1.Length) / 2, 6);
            Console.WriteLine(upgradeQuestion1);
            Console.SetCursorPosition((Console.WindowWidth - upgradeQuestion2.Length) / 2, 7);
            Console.WriteLine(upgradeQuestion2);

            (finished, selected) = ListNavigation.scrollList(upgradeStrings, 9, finished);

            int toBuy = (int)(NewPlayer.wallet / upgradePrices[selected]);

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            if (finished != true)
                do
                {
                    Console.Clear();
                    UserMenu(CurrentPlanet);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    string howMuch1 = $"So you'd like to buy {toBuyStrings[selected]} for #{upgradePrices[selected]}?";

                    Console.SetCursorPosition((Console.WindowWidth - howMuch1.Length) / 2, 6);
                    Console.WriteLine(howMuch1);

                    if (selected == 0)
                    {
                        do
                        {
                            Console.SetCursorPosition(0, 10);
                            Console.Write("Buy ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(toBuy);
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" Kerbal gallons of rocket fuel for ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write($"#{toBuy * upgradePrices[selected]}");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("?");
                            cki = Console.ReadKey(true);
                            switch (cki.Key)
                            {
                                case ConsoleKey.DownArrow:

                                    if (toBuy > 0)
                                    {
                                        toBuy -= 1;
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                case ConsoleKey.UpArrow:

                                    if (toBuy < (int)(NewPlayer.wallet / upgradePrices[selected]))
                                    {
                                        toBuy += 1;
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                case ConsoleKey.Escape:
                                    finished = true;
                                    break;
                            }


                        } while (cki.Key != ConsoleKey.Enter);
                    }
                    else
                    {
                        if (finished != true && NewPlayer.wallet >= upgradePrices[selected])
                        {
                            toBuy = 1;
                            NewPlayer.wallet -= (upgradePrices[selected] * toBuy);
                            if (selected == 1)
                            {
                                NewShip.maxFuel += upgradeAdds[selected];

                            }
                            else if (selected == 2)
                            {
                                NewShip.fuelPerLightYear -= NewShip.fuelPerLightYear / upgradeAdds[selected]; //reduces fuel/lightyear by 10%
                            }
                            else if (selected == 3)
                            {
                                NewShip.maxInventory += upgradeAdds[selected];
                            }
                            else if (selected == 4)
                            {
                                NewShip.warpFactor += 1;
                            }
                            finished = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 10);
                            Console.WriteLine("You can not afford this upgrade. Keep trading.");
                            Console.ReadLine();
                            finished = true;
                        }
                    }

                    if (finished != true && selected == 0)
                    {
                        NewPlayer.wallet -= (upgradePrices[selected] * toBuy);
                        NewShip.currentFuel += toBuy;
                        finished = true;
                    }
                } while (finished != true);
            Actions.UpdateInventoryTotal();
            Console.Clear();
            UserMenu(CurrentPlanet);
        }



        public static void TradeMenu(Planet CurrentPlanet)
        {
            Actions.UpdateMarketPrices(CurrentPlanet);

            int selectedGood = 0;
            int buyOrSell = 0;
            int cursorCurrent = 9;
            bool finished = false;

            List<double> productPrices = new List<double>()
            {
                 CurrentMarket.air,
                 CurrentMarket.fur,
                 CurrentMarket.robot,
                 CurrentMarket.doors,
                 CurrentMarket.seeds
            };

            List<string> productStrings = new List<string>()
            {
                 "Canned Earth Air",
                 "Proxima Centaurian Fur",
                 "Gazorpian Service Robot",
                 "Real Fake Doors",
                 "Mega Tree Seeds"
            };

            List<string> buySell = new List<string>()
            {
                "Buy",
                "Sell"
            };

            Console.Clear();
            UserMenu(CurrentPlanet);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string tradeQuestion1 = "Use the UP and DOWN arrow keys to select a good " +
                "to trade, then press enter.";
            string tradeQuestion2 = "Press ESC to cancel";

            Console.SetCursorPosition((Console.WindowWidth - tradeQuestion1.Length) / 2, 6);
            Console.WriteLine(tradeQuestion1);
            Console.SetCursorPosition((Console.WindowWidth - tradeQuestion2.Length) / 2, 7);
            Console.WriteLine(tradeQuestion2);
            Console.SetCursorPosition(Console.CursorLeft, 9);

            Console.WriteLine($"{productStrings[0]}");
            Console.WriteLine($"      Price: #{productPrices[0]}");
            Console.WriteLine($"      On Hand: {Products.productList[0].onHand}");
            Console.WriteLine();
            Console.WriteLine($"{productStrings[1]}");
            Console.WriteLine($"      Price: #{productPrices[1]}");
            Console.WriteLine($"      On Hand: {Products.productList[1].onHand}");
            Console.WriteLine();
            Console.WriteLine($"{productStrings[2]}");
            Console.WriteLine($"      Price: #{productPrices[2]}");
            Console.WriteLine($"      On Hand: {Products.productList[2].onHand}");
            Console.WriteLine();
            Console.WriteLine($"{productStrings[3]}");
            Console.WriteLine($"      Price: #{productPrices[3]}");
            Console.WriteLine($"      On Hand: {Products.productList[3].onHand}");
            Console.WriteLine();
            Console.WriteLine($"{productStrings[4]}");
            Console.WriteLine($"      Price: #{productPrices[4]}");
            Console.Write($"      On Hand: {Products.productList[4].onHand}");

            Console.SetCursorPosition(0, cursorCurrent);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{productStrings[0]}");
            Console.ResetColor();
            Console.SetCursorPosition(0, 6);

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            do
            {
                if (finished != true)
                {
                    do
                    {
                        cki = Console.ReadKey(true);
                        switch (cki.Key)
                        {

                            case ConsoleKey.DownArrow:
                                if (cursorCurrent < 25)
                                {
                                    Console.SetCursorPosition(0, cursorCurrent);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write($"{productStrings[selectedGood]}");

                                    cursorCurrent = cursorCurrent + 4;
                                    selectedGood = selectedGood + 1;

                                    Console.SetCursorPosition(0, cursorCurrent);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    Console.Write($"{productStrings[selectedGood]}");
                                    Console.ResetColor();
                                    Console.SetCursorPosition(0, 6);
                                    break;
                                }
                                else
                                {
                                    break;
                                }

                            case ConsoleKey.UpArrow:

                                if (cursorCurrent > 9)
                                {
                                    Console.SetCursorPosition(0, cursorCurrent);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write($"{productStrings[selectedGood]}");

                                    cursorCurrent = cursorCurrent - 4;
                                    selectedGood = selectedGood - 1;

                                    Console.SetCursorPosition(0, cursorCurrent);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    Console.Write($"{productStrings[selectedGood]}");
                                    Console.ResetColor();
                                    Console.SetCursorPosition(0, 6);
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            case ConsoleKey.Escape:
                                finished = true;
                                break;
                        }
                    } while (cki.Key != ConsoleKey.Enter && finished != true);
                }

                Console.Clear();
                UserMenu(CurrentPlanet);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string buyOrSell1 = $"Buy or Sell {Products.productList[selectedGood].unit} at #{productPrices[selectedGood]}.";
                string buyOrSell2 = "Enter to confirm | ESC to cancel";

                Console.SetCursorPosition((Console.WindowWidth - buyOrSell1.Length) / 2, 6);
                Console.WriteLine(buyOrSell1);
                Console.SetCursorPosition((Console.WindowWidth - buyOrSell2.Length) / 2, 7);
                Console.WriteLine(buyOrSell2);

                if (finished != true)
                {
                    (finished, buyOrSell) = ListNavigation.scrollList(buySell, 9, finished);
                }

                int toBuy = (int)(NewPlayer.wallet / productPrices[selectedGood]);
                int toSell = Products.productList[selectedGood].onHand;
                if (finished != true)
                {
                    do
                    {
                        Console.Clear();
                        UserMenu(CurrentPlanet);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string howMuch1 = $"So you'd like to {buySell[buyOrSell]} {Products.productList[selectedGood].unit} for #{productPrices[selectedGood]}?";

                        Console.SetCursorPosition((Console.WindowWidth - howMuch1.Length) / 2, 6);
                        Console.WriteLine(howMuch1);

                        string controls = "Use the UP and DOWN arrow keys to change the quantity | ENTER to confirm.";
                        Console.SetCursorPosition((Console.WindowWidth - controls.Length) / 2, 8);
                        Console.WriteLine(controls);

                        if (buyOrSell == 0)
                        {
                            Console.SetCursorPosition(0, 10);
                            Console.Write("Buy ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(toBuy);
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" {Products.productList[selectedGood].unit} for ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write($"#{toBuy * productPrices[selectedGood]}");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("?");
                        }
                        else
                        {
                            if (Products.productList[selectedGood].onHand == 0)
                            {
                                Console.SetCursorPosition(0, 10);
                                Console.Write($"You have no {Products.productList[selectedGood].unit} to sell.");
                                finished = true;
                            }
                            else
                            {
                                Console.SetCursorPosition(0, 10);
                                Console.Write("Sell ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.Write(toSell);
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write($" {Products.productList[selectedGood].unit} for ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.Write($"#{toSell * productPrices[selectedGood]}");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("?");
                            }
                        }
                        if (finished != true)
                        {
                            cki = Console.ReadKey(true);
                            switch (cki.Key)
                            {
                                case ConsoleKey.DownArrow:
                                    if (buyOrSell == 0)
                                    {
                                        if (toBuy > 0)
                                        {
                                            toBuy = toBuy - 1;
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (toSell > 0)
                                        {
                                            toSell = toSell - 1;
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                case ConsoleKey.UpArrow:
                                    if (buyOrSell == 0)
                                    {
                                        if (toBuy < (int)(NewPlayer.wallet / productPrices[selectedGood]))
                                        {
                                            toBuy = toBuy + 1;
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (toSell < Products.productList[selectedGood].onHand)
                                        {
                                            toSell = toSell + 1;
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                case ConsoleKey.Escape:
                                    finished = true;
                                    break;
                            }
                        }
                        else
                        {
                            cki = Console.ReadKey(true);
                            switch (cki.Key)
                            {

                                case ConsoleKey.Escape:
                                    finished = true;
                                    break;
                            }
                        }
                    } while (cki.Key != ConsoleKey.Enter && finished != true);
                }


                if (buyOrSell == 0 && finished != true)
                {
                    NewPlayer.wallet = NewPlayer.wallet - (productPrices[selectedGood] * toBuy);
                    Products.productList[selectedGood].onHand = Products.productList[selectedGood].onHand + toBuy;
                    finished = true;
                }
                else if (buyOrSell == 1 && finished != true)
                {
                    NewPlayer.wallet = NewPlayer.wallet + (productPrices[selectedGood] * toSell);
                    Products.productList[selectedGood].onHand = Products.productList[selectedGood].onHand - toSell;
                    finished = true;
                }
                else { }
            }
            while (finished != true);
            Actions.UpdateInventoryTotal();
            Console.Clear();
            UserMenu(CurrentPlanet);
        }

        public static Planet TravelMenu(Planet CurrentPlanet)
        {
            ConsoleKey rKey;
            int selectionTravel = 1;
            Planet PlaceHolder = CurrentPlanet;
            do
            {
                Console.Clear();
                UserMenu(CurrentPlanet);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string travelQuestion = "Use the left and right arrow keys to select where you want " +
                    "to travel, then press enter.";

                Console.SetCursorPosition((Console.WindowWidth - travelQuestion.Length) / 2, 6);
                Console.WriteLine(travelQuestion);

                string selectionTravelString = $"{selectionTravel} / {planetTravel.Length}";
                Console.SetCursorPosition((Console.WindowWidth - selectionTravelString.Length) / 2, 7);
                Console.WriteLine(selectionTravelString);

                PlanetTravelFunction(selectionTravel - 1, CurrentPlanet);
                rKey = Console.ReadKey().Key;
                if (rKey == ConsoleKey.LeftArrow)
                {
                    if (selectionTravel - 1 == 0)
                    {
                        selectionTravel = planetTravel.Length;
                    }
                    else
                    {
                        selectionTravel--;
                    }
                }
                if (rKey == ConsoleKey.RightArrow)
                {
                    if (selectionTravel + 1 > planetTravel.Length)
                    {
                        selectionTravel = 1;
                    }
                    else
                    {
                        selectionTravel++;
                    }
                }
                if (rKey == ConsoleKey.Enter)
                {
                    Console.WriteLine($"Do you want to travel to {planetTravel[selectionTravel - 1].name}?");
                    Console.WriteLine("Press Enter to confirm or Escape to cancel.\n");
                    rKey = Console.ReadKey().Key;
                    if (rKey == ConsoleKey.Enter)
                    {
                        bool travelAble = Actions.ChangePlanets(planetTravel[selectionTravel - 1], CurrentPlanet);
                        if (travelAble == false)
                        {
                            return PlaceHolder;
                        }
                        else
                        {
                            return planetTravel[selectionTravel - 1];
                        }
                    }
                }
            } while (rKey != ConsoleKey.Escape);
            return PlaceHolder;
        }

        public static void PlanetTravelFunction(int planetSel, Planet CurrentPlanet)
        {

            Console.SetCursorPosition((Console.WindowWidth - planetTravel[planetSel].name.Length - 18) / 2, 8);

            Console.WriteLine($"<----    {planetTravel[planetSel].name}    ---->");

            Draw.DrawImage(planetTravel[planetSel].imageFile, (Console.WindowWidth / 2), Console.WindowHeight / 5, 45);

            Console.SetCursorPosition(Console.CursorLeft, 14);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Description: " + planetTravel[planetSel].description);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Inhabitants: " + planetTravel[planetSel].inhabitants);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Travel Distance: " + Equations.DistanceTo(planetTravel[planetSel], CurrentPlanet) + " light years");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Travel Time: " + Equations.TravelTime(Equations.DistanceTo(planetTravel[planetSel], CurrentPlanet)) + " years");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Fuel Cost: #" + (NewShip.fuelPerLightYear * Equations.DistanceTo(planetTravel[planetSel], CurrentPlanet)));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Danger Rating: " + planetTravel[planetSel].dangerRating);
            Console.WriteLine();
            Console.WriteLine();
            if (planetSel == 3)
            {
                Console.WriteLine(planetTravel[4].screamingProduct);
            }
            else
            {
                Market displayMarket = planetMarket[planetSel];
                double[] displayMarket2 = {displayMarket.air, displayMarket.fur, displayMarket.robot, displayMarket.doors, displayMarket.seeds };

                Console.Write("Product Prices: ");

                int cursor = Console.CursorTop;
                int i = 0;
                foreach (var x in displayMarket2)
                {
                    Console.SetCur+
                        0 
            //PlanetProducePrint(planetSel+1);
        }
        public static void PlanetProducePrint(int sel)
        {
            switch (sel)
            {
                case 1:
                    Console.WriteLine("Current Product Unit Prices");
                    Console.WriteLine();
                    Console.WriteLine("Canned Earth Air: #" + Products.earthPrices.air);
                    Console.WriteLine();
                    Console.WriteLine("Proxima Centaurian Fur: #" + Products.earthPrices.fur);
                    Console.WriteLine();
                    Console.WriteLine("Gazorpian Service Robot: #" + Products.earthPrices.robot);
                    Console.WriteLine();
                    Console.WriteLine("Real Fake Door: #" + Products.earthPrices.doors);
                    Console.WriteLine();
                    Console.WriteLine("Mega Tree Seed: #" + Products.earthPrices.seeds);
                    break;
                case 2:
                    Console.WriteLine("Current Product Prices");
                    Console.WriteLine();
                    Console.WriteLine("Canned Earth Air: #" + Products.proximaPrices.air);
                    Console.WriteLine();
                    Console.WriteLine("Proxima Centaurian Fur: #" + Products.proximaPrices.fur);
                    Console.WriteLine();
                    Console.WriteLine("Gazorpian Service Robot: #" + Products.proximaPrices.robot);
                    Console.WriteLine();
                    Console.WriteLine("Real Fake Door: #" + Products.proximaPrices.doors);
                    Console.WriteLine();
                    Console.WriteLine("Mega Tree Seed: #" + Products.proximaPrices.seeds);
                    break;
                case 3:
                    Console.WriteLine("Current Product Prices");
                    Console.WriteLine();
                    Console.WriteLine("Canned Earth Air: #" + Products.gazorpazorpPrices.air);
                    Console.WriteLine();
                    Console.WriteLine("Proxima Centaurian Fur: #" + Products.gazorpazorpPrices.fur);
                    Console.WriteLine();
                    Console.WriteLine("Gazorpian Service Robot: #" + Products.gazorpazorpPrices.robot);
                    Console.WriteLine();
                    Console.WriteLine("Real Fake Door: #" + Products.gazorpazorpPrices.doors);
                    Console.WriteLine();
                    Console.WriteLine("Mega Tree Seed: #" + Products.gazorpazorpPrices.seeds);
                    break;
                case 4:
                    Console.WriteLine("Current Product Prices");
                    Console.WriteLine();
                    Console.WriteLine("Canned Earth Air: #" + Products.screamingPrices.air);
                    Console.WriteLine();
                    Console.WriteLine("Proxima Centaurian Fur: #" + Products.screamingPrices.fur);
                    Console.WriteLine();
                    Console.WriteLine("Gazorpian Service Robot: #" + Products.screamingPrices.robot);
                    Console.WriteLine();
                    Console.WriteLine("Real Fake Door: #" + Products.screamingPrices.doors);
                    Console.WriteLine();
                    Console.WriteLine("Mega Tree Seed: #" + Products.screamingPrices.seeds);
                    break;
                case 5:
                    Console.WriteLine("Current Product Prices");
                    Console.WriteLine();
                    Console.WriteLine("Canned Earth Air: #" + Products.c35Prices.air);
                    Console.WriteLine();
                    Console.WriteLine("Proxima Centaurian Fur: #" + Products.c35Prices.fur);
                    Console.WriteLine();
                    Console.WriteLine("Gazorpian Service Robot: #" + Products.c35Prices.robot);
                    Console.WriteLine();
                    Console.WriteLine("Real Fake Door: #" + Products.c35Prices.doors);
                    Console.WriteLine();
                    Console.WriteLine("Mega Tree Seed: #" + Products.c35Prices.seeds);
                    break;
                case 6:
                    Console.WriteLine("Current Product Prices");
                    Console.WriteLine();
                    Console.WriteLine("Canned Earth Air: #" + Products.gromflomPrices.air);
                    Console.WriteLine();
                    Console.WriteLine("Proxima Centaurian Fur: #" + Products.gromflomPrices.fur);
                    Console.WriteLine();
                    Console.WriteLine("Gazorpian Service Robot: #" + Products.gromflomPrices.robot);
                    Console.WriteLine();
                    Console.WriteLine("Real Fake Door: #" + Products.gromflomPrices.doors);
                    Console.WriteLine();
                    Console.WriteLine("Mega Tree Seed: #" + Products.gromflomPrices.seeds);
                    break;
            }

        }

    }
}