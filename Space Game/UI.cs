using System;
using System.Collections.Generic;
using static SpaceGame.Game;
using static SpaceGame.Universe;
using System.IO;

namespace SpaceGame
{
    public static class UI
    {
        public static int currentSelection = 0;
        public static void UserMenu()
        {
            int i = Console.CursorTop;
            string menu = "|    F1 - Your Statistics        F2 - Ship Inventory         F3 - Trade        F4 - Travel        F5 - Save        F12 - Exit Game    |";
            string line = "-";
            string menu2 = $"Galactic Federation Credits: {NewPlayer.wallet} Fuel: {NewShip.currentFuel}/{NewShip.maxFuel} Age: {NewPlayer.age} Year: {NewPlayer.currentYear} InvSpace: {NewShip.currentInventory}/{NewShip.maxInventory} CurrentPlanet: {CurrentPlanet.name}";

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

        public static void MenuSelection()
        {
            bool gameFinish = false;
            do
            {
                StoryLine.StoryCheck(NewPlayer.numOfProductsSold);
                Console.Clear();
                UserMenu();
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
                        //TradeMenu();
                        break;

                    case ConsoleKey.F4:
                        TravelMenu();
                        break;

                    case ConsoleKey.F5:
                        Actions.SaveGame();
                        break;

                    case ConsoleKey.F6://Load game?
                        break;

                    case ConsoleKey.F12:
                        Actions.SaveGame();
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


        public static void TradeMenu()
        {
            Actions.UpdateMarketPrices();

            int selectedGood = 0;
            int buyOrSell = 0;
            int cursorCurrent = 9;
            bool finished = false;

            List<double> productPrices = new List<double>()
            {
                 Game.CurrentMarket.air,
                 Game.CurrentMarket.fur,
                 Game.CurrentMarket.robot,
                 Game.CurrentMarket.doors,
                 Game.CurrentMarket.seeds
            };

            List<string> productStrings = new List<string>()
            {
                 "Canned Earth Air: ",
                 "Proxima Centaurian Fur: ",
                 "Gazorpian Service Robot: ",
                 "Real Fake Doors: ",
                 "Mega Tree Seeds: "
            };

            List<string> buySell = new List<string>()
            {
                "Buy",
                "Sell"
            };

            Console.Clear();
            UserMenu();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string tradeQuestion1 = "Use the UP and DOWN arrow keys to select a good " +
                "to trade, then press enter.";
            string tradeQuestion2 = "Press ESC to cancel";

            Console.SetCursorPosition((Console.WindowWidth - tradeQuestion1.Length) / 2, 6);
            Console.WriteLine(tradeQuestion1);
            Console.SetCursorPosition((Console.WindowWidth - tradeQuestion2.Length) / 2, 7);
            Console.WriteLine(tradeQuestion2);
            Console.SetCursorPosition(Console.CursorLeft, 9);

            Console.WriteLine(productStrings[0] + productPrices[0]);
            Console.WriteLine();
            Console.WriteLine(productStrings[1] + productPrices[1]);
            Console.WriteLine();
            Console.WriteLine(productStrings[2] + productPrices[2]);
            Console.WriteLine();
            Console.WriteLine(productStrings[3] + productPrices[3]);
            Console.WriteLine();
            Console.Write(productStrings[4] + productPrices[4]);

            Console.SetCursorPosition(0, cursorCurrent);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(productStrings[selectedGood] + productPrices[selectedGood]);
            Console.ResetColor();
            Console.SetCursorPosition(0, 6);

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            do
            {
                do
                {
                    cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {

                        case ConsoleKey.DownArrow:
                            if (cursorCurrent < 17)
                            {
                                Console.SetCursorPosition(0, cursorCurrent);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write(productStrings[selectedGood] + productPrices[selectedGood]);

                                cursorCurrent = cursorCurrent + 2;
                                selectedGood = selectedGood + 1;

                                Console.SetCursorPosition(0, cursorCurrent);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.Write(productStrings[selectedGood] + productPrices[selectedGood]);
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
                                Console.Write(productStrings[selectedGood] + productPrices[selectedGood]);

                                cursorCurrent = cursorCurrent - 2;
                                selectedGood = selectedGood - 1;

                                Console.SetCursorPosition(0, cursorCurrent);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.Write(productStrings[selectedGood] + productPrices[selectedGood]);
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 6);
                                break;
                            }
                            else
                            {
                                break;
                            }
                    }
                }
                while (cki.Key != ConsoleKey.Enter);
                Console.Clear();
                UserMenu();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string buyOrSell1 = $"Buy or Sell {Products.productList[selectedGood].unit} at {productPrices[selectedGood]}.";
                string buyOrSell2 = "Enter to confirm | ESC to cancel";

                Console.SetCursorPosition((Console.WindowWidth - buyOrSell1.Length) / 2, 6);
                Console.WriteLine(buyOrSell1);
                Console.SetCursorPosition((Console.WindowWidth - buyOrSell2.Length) / 2, 7);
                Console.WriteLine(buyOrSell2);

                Console.SetCursorPosition(Console.CursorLeft, 9);

                Console.WriteLine("Buy");
                Console.WriteLine();
                Console.Write("Sell");

                cursorCurrent = 9;

                Console.SetCursorPosition(0, cursorCurrent);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(buySell[buyOrSell]);
                Console.ResetColor();
                Console.SetCursorPosition(0, 6);
                do
                {

                    cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (cursorCurrent < 11)
                            {
                                Console.SetCursorPosition(0, cursorCurrent);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write(buySell[buyOrSell]);

                                cursorCurrent = cursorCurrent + 2;
                                buyOrSell = buyOrSell + 1;

                                Console.SetCursorPosition(0, cursorCurrent);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.Write(buySell[buyOrSell]);
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
                                Console.Write(buySell[buyOrSell]);

                                cursorCurrent = cursorCurrent - 2;
                                buyOrSell = buyOrSell - 1;

                                Console.SetCursorPosition(0, cursorCurrent);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.Write(buySell[buyOrSell]);
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 6);
                                break;
                            }
                            else
                            {
                                break;
                            }

                    }
                }
                while (cki.Key != ConsoleKey.Enter);

                int toBuy = (int)(NewPlayer.wallet / productPrices[selectedGood]);
                int toSell = Products.productList[selectedGood].onHand;

                do
                {
                    Console.Clear();
                    UserMenu();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    string howMuch1 = $"So you'd like to {buySell[buyOrSell]} {Products.productList[selectedGood].unit} for {productPrices[selectedGood]}?";

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
                        Console.Write($"{toBuy * productPrices[selectedGood]}");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("?");
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
                        Console.Write($"{toSell * productPrices[selectedGood]}");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("?");
                    }
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
                    }
                }
                while (cki.Key != ConsoleKey.Enter);

                if (buyOrSell == 0)
                {
                    NewPlayer.wallet = NewPlayer.wallet - (productPrices[selectedGood] * toBuy);
                    Products.productList[selectedGood].onHand = Products.productList[selectedGood].onHand + toBuy;
                    finished = true;
                }
                else
                {
                    NewPlayer.wallet = NewPlayer.wallet + (productPrices[selectedGood] * toSell);
                    Products.productList[selectedGood].onHand = Products.productList[selectedGood].onHand - toSell;
                    finished = true;
                }
            }
            while (finished != true);
            Console.Clear();
            UserMenu();
        }

        public static void TravelMenu()
        {
            ConsoleKey rKey;
            int selectionTravel = 1;

            do
            {
                Console.Clear();
                UserMenu();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string travelQuestion = "Use the left and right arrow keys to select where you want " +
                    "to travel, then press enter.";

                Console.SetCursorPosition((Console.WindowWidth - travelQuestion.Length) / 2, 6);
                Console.WriteLine(travelQuestion);

                string selectionTravelString = $"{selectionTravel} / {planetTravel.Length}";
                Console.SetCursorPosition((Console.WindowWidth - selectionTravelString.Length) / 2, 7);
                Console.WriteLine(selectionTravelString);

                PlanetTravelFunction(selectionTravel - 1);
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
                        Actions.ChangePlanets(planetTravel[selectionTravel - 1]);
                        break;
                    }
                }

            } while (rKey != ConsoleKey.Escape);
        }

        public static void PlanetTravelFunction(int planetSel)
        {

            Console.SetCursorPosition((Console.WindowWidth - Universe.planetTravel[planetSel].name.Length - 18) / 2, 8);

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
            Console.WriteLine("Travel Distance: " + Equations.DistanceTo(planetTravel[planetSel]));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Travel Time: " + Equations.TravelTime(Equations.DistanceTo(planetTravel[planetSel])));
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
                Console.WriteLine("Product Prices: ");
            }
            Console.WriteLine();
        }

    }
}

//public static void PrintPage (List<string> List)
//{
//    UserMenu ();
//    int displayLength = List.Count;
//    if (displayLength + currentSelection >= List.Count)
//    {
//        displayLength = List.Count - currentSelection;
//    }
//    List<string> display = List.GetRange (currentSelection, displayLength);
//    for (int i = 0; i < displayLength; i++)
//    {
//        if (i == currentSelection)
//        {
//            Console.ForegroundColor = ConsoleColor.Black;
//            Console.BackgroundColor = ConsoleColor.White;
//        }
//        else if (List [i + currentSelection].StartsWith ("* /"))
//        {
//            Console.ForegroundColor = ConsoleColor.DarkGray;
//        }

//        string elem = display [i];
//        Console.WriteLine (elem.ToString ());

//        Console.ForegroundColor = ConsoleColor.White;
//        Console.BackgroundColor = ConsoleColor.Black;
//    }
//    Console.SetCursorPosition (Console.CursorLeft, 6);
//}