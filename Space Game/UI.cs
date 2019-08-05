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
            string menu2 = $"Galactic Federation Credits: {NewPlayer.wallet} Fuel: {NewShip.currentFuel}/{NewShip.maxFuel} Age: {NewPlayer.age} Year: {NewPlayer.currentYear} InvSpace: {NewShip.currentInventory}/{NewShip.maxInventory} CurrentPlanet: {CurrentPlanet}";

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

        public static void ShipStatsMenu()
        {
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

            // ship image here
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
            Console.WriteLine("Total Galactic Credits Stolen By Pirates: " + NewPlayer.totalMoneyStolen);
            Console.WriteLine();
            Console.WriteLine("Number Of Pirates Killed: " + NewPlayer.totalPiratesThwarted);
            Console.WriteLine();
            Console.WriteLine("Total Pirate Attacks Stopped: " + NewPlayer.totalPassedPirateAttacks);
            Console.WriteLine();
            Console.WriteLine("Total Pirate Attacks Failed: " + NewPlayer.totalFailedPirateAttacks);
        }

        /*
        public static void TradeMenu()
        {
            Actions.UpdateMarketPrices();

            int selectedGood = 0;
            int buyOrSell = 0;
            int cursorCurrent = 9;

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
            string tradeQuestion1 = "Use the up and down arrow keys to select a good " +
                "to trade, then press enter.";
            string tradeQuestion2 = "Press esc to cancel";

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
            Console.ForegroundColor = ConsoleColor.DarkGreen;
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
                        break;
                        }
                        else
                        {
                        break;
                        }
                }
                while (cki.Key != ConsoleKey.Enter);
                Console.Clear();
                UserMenu();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    string buyOrSell1 = $"Buy or Sell {Products.productList[selectedGood]} at {productPrices[selectedGood]}.";
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
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
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
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                        
                    }
                    while (cki.Key != ConsoleKey.Enter);
                    Console.Clear();
                    UserMenu();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        string howMuch1 = $"So you'd like to {buySell[buyOrSell]} {Products.productList[selectedGood]} at {productPrices[selectedGood]}?";

                        Console.SetCursorPosition((Console.WindowWidth - howMuch1.Length) / 2, 6);
                        Console.WriteLine(howMuch1);

                        if (buyOrSell == 0)
                        {
                            int canAfford = (int)(NewPlayer.wallet / productPrices[selectedGood]);
                            string howMuch2 = $"You can afford {canAfford}.";
                            Console.SetCursorPosition((Console.WindowWidth - howMuch2.Length) / 2, 8);
                            Console.WriteLine(howMuch2);
                        }
                        else
                        {
                            string howMuch2 = $"You have {Products.productList[selectedGood].onHand} to sell.";
                            Console.SetCursorPosition((Console.WindowWidth - howMuch2.Length) / 2, 8);
                            Console.WriteLine(howMuch2);
                        }
                        Console.SetCursorPosition(Console.WindowLeft, 10);
                        Console.WriteLine($"How much would you like to {buySell[buyOrSell]}?\n");
                        int input = 0;
                        do
                        {
                            try
                            {
                                input = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.Clear();
                                UserMenu();
                                Console.SetCursorPosition(Console.WindowLeft, 8);
                                Console.WriteLine("Try again.\n");
                            }
                        }
                        while (input == 0);

                        if (buyOrSell == 0)
                        {
                            do
                            {
                                Console.Clear();
                                UserMenu();
                                Console.SetCursorPosition(Console.WindowLeft, 6);
                                Console.WriteLine($"You can't afford {input} {Products.productList[selectedGood]}.\n");
                                Console.WriteLine($"How much would you like to {buySell[buyOrSell]}?\n");
                                input = int.Parse(Console.ReadLine());
                            }
                            while (input > (int)(NewPlayer.wallet / productPrices[selectedGood]));

                            Console.WriteLine($"\nBuy {input} {Products.productList[selectedGood]}?\n");
                            Console.WriteLine("ESC to Cancel | Enter to Confirm.\n");
                            Console.ReadLine();
                            NewPlayer.wallet = NewPlayer.wallet - (productPrices[selectedGood] * input);
                            Products.productList[selectedGood].onHand = Products.productList[selectedGood].onHand + input;
                            Console.Clear();
                            UserMenu();
                        }
                        else
                        {

                        }
            while (cki.Key != ConsoleKey.Escape);
            Console.Clear();
            UserMenu();

            

                if (rKey == ConsoleKey.Enter)
                {
                    NewPlayer.wallet = NewPlayer.wallet - (productPrices[selectedGood] * input);
                    Products.productList[selectedGood].onHand = Products.productList[selectedGood].onHand + input;
                    Console.Clear();
                    UserMenu();
                }
            }
            else
            {
                do
                {
                    Console.Clear();
                    UserMenu();
                    Console.SetCursorPosition(Console.WindowLeft, 6);
                    Console.WriteLine($"You don't have {input} to sell.\n");
                    Console.WriteLine($"How much would you like to {buySell[buyOrSell]}?\n");
                    input = int.Parse(Console.ReadLine());
                }
                while (input > Products.productList[selectedGood].onHand);

                Console.WriteLine($"\nSell {input} {Products.productList[selectedGood]}?\n");

                if (rKey == ConsoleKey.Enter)
                {
                    NewPlayer.wallet = NewPlayer.wallet + (productPrices[selectedGood] * input);
                    Products.productList[selectedGood].onHand = Products.productList[selectedGood].onHand - input;
                    Console.Clear();
                    UserMenu();
                }
            }
        }
    }
            
}
*/

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


    } while (rKey != ConsoleKey.Enter);

    Console.WriteLine($"Do you want to travel to {planetTravel[selectionTravel - 1].name}?");
    Console.WriteLine("Press Enter to confirm or Escape to cancel.");
    rKey = Console.ReadKey().Key;
    if (rKey == ConsoleKey.Enter)
    {
        Actions.ChangePlanets(planetTravel[selectionTravel - 1]);
    }
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
    Console.WriteLine("Travel Distance: ");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Travel Time: ");
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