using System;
using System.Collections.Generic;
using static SpaceGame.Game;
using static SpaceGame.Universe;

namespace SpaceGame
{
    public static class UI
    {
        public static int currentSelection = 0;
        public static void UserMenu ()
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
                    Console.SetCursorPosition (r, 0);
                    Console.Write (line);

                }
                Console.SetCursorPosition ((((Console.BufferWidth) - menu.Length) / 2), 1);
                Console.Write (menu);
            }

            for (int r = 0; r < Console.BufferWidth; r++)
            {
                Console.SetCursorPosition (r, 2);
                Console.Write (line);
            }

            for (int r = 0; r < Console.BufferWidth; r++)
            {
                Console.SetCursorPosition (r, (Console.BufferHeight - 3));
                Console.Write (line);

            }
            Console.SetCursorPosition ((Console.BufferWidth - menu2.Length) / 2, Console.BufferHeight - 2);
            Console.Write (menu2);
            for (int r = 0; r < Console.BufferWidth; r++)
            {
                Console.SetCursorPosition (r, (Console.BufferHeight - 1));
                Console.Write (line);

            }
            Console.SetCursorPosition (Console.CursorLeft, 6);   //is this necessary? YES. YES IT IS.

        }

        public static void ShipStatsMenu ()
        {
            Console.SetCursorPosition (Console.CursorLeft, 6);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition (0, 6);
            Console.WriteLine ("Ship Name: " + NewShip.name);
            Console.WriteLine ();
            Console.WriteLine ("Warp Factor: " + NewShip.warpFactor);
            Console.WriteLine ();
            Console.WriteLine ($"Fuel: {NewShip.currentFuel}/{NewShip.maxFuel}");
            Console.WriteLine ();
            Console.WriteLine ($"Fuel Per Lightyear: {NewShip.fuelPerLightYear}");
            Console.WriteLine ();
            Console.WriteLine ($"Inventory: {NewShip.currentInventory}/{NewShip.maxInventory}");

            // ship image here
        }

        public static void PlayerStatsMenu ()
        {
            Console.SetCursorPosition (Console.CursorLeft, 6);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine ("Your Name: " + NewPlayer.name);
            Console.WriteLine ();
            Console.WriteLine ("Your Age: " + NewPlayer.age);
            Console.WriteLine ();
            Console.WriteLine ("Galactic Federation Credits: " + NewPlayer.wallet);
            Console.WriteLine ();
            Console.WriteLine ("Total Products Sold: " + NewPlayer.numOfProductsSold);
            Console.WriteLine ();
            Console.WriteLine ("Total Distance Traveled: " + NewPlayer.totalDistanceTraveled);
            Console.WriteLine ();
            Console.WriteLine ("Total Galactic Credits Earned: " + NewPlayer.totalMoneyEarned);
            Console.WriteLine ("Total Galactic Credits Stolen By Pirates: " + NewPlayer.totalMoneyStolen);
            Console.WriteLine ();
            Console.WriteLine ("Number Of Pirates Killed: " + NewPlayer.totalPiratesThwarted);
            Console.WriteLine ();
            Console.WriteLine ("Total Pirate Attacks Stopped: " + NewPlayer.totalPassedPirateAttacks);
            Console.WriteLine ();
            Console.WriteLine ("Total Pirate Attacks Failed: " + NewPlayer.totalFailedPirateAttacks);
        }

        public static void TradeMenu ()
        {
            Console.SetCursorPosition (Console.CursorLeft, 6);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write ("What would you like to trade?");

            // need to either iterate through a list or assign buttons to it. Preferably iterate but depends on the difficulty of implementaion.
        }

        public static void TravelMenu ()
        {
            ConsoleKey rKey;
            int selectionTravel = 1;

            do
            {
                Console.Clear ();
                UserMenu ();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string travelQuestion = "Use the left and right arrow keys to select where you want " +
                    "to travel, then press enter.";

                Console.SetCursorPosition ((Console.WindowWidth - travelQuestion.Length) / 2, 6);
                Console.WriteLine (travelQuestion);

                string selectionTravelString = $"{selectionTravel} / {planetTravel.Length}";
                Console.SetCursorPosition ((Console.WindowWidth - selectionTravelString.Length) / 2, 7);
                Console.WriteLine (selectionTravelString);

                PlanetTravelFunction (selectionTravel - 1);
                rKey = Console.ReadKey ().Key;
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

            Console.WriteLine ($"Do you want to travel to {planetTravel [selectionTravel - 1].name}?");
            Console.WriteLine ("Press Enter to confirm or Escape to cancel.");
            rKey = Console.ReadKey ().Key;
            if (rKey == ConsoleKey.Enter)
            {
                Actions.changePlanets (planetTravel [selectionTravel - 1]);
            }
        }

        public static void PlanetTravelFunction (int planetSel)
        {

            Console.SetCursorPosition ((Console.WindowWidth - Universe.planetTravel [planetSel].name.Length - 18) / 2, 8);

            Console.WriteLine ($"<----    {planetTravel [planetSel].name}    ---->");

            Draw.DrawImage (planetTravel [planetSel].imageFile, (Console.WindowWidth / 2), Console.WindowHeight / 5, 45);

            Console.SetCursorPosition (Console.CursorLeft, 14);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine ("Description: " + planetTravel [planetSel].description);
            Console.WriteLine ();
            Console.WriteLine ();
            Console.WriteLine ();
            Console.WriteLine ("Inhabitants: " + planetTravel [planetSel].inhabitants);
            Console.WriteLine ();
            Console.WriteLine ();
            Console.WriteLine ("Travel Distance: ");
            Console.WriteLine ();
            Console.WriteLine ();
            Console.WriteLine ("Travel Time: ");
            Console.WriteLine ();
            Console.WriteLine ();
            Console.WriteLine ("Danger Rating: " + planetTravel [planetSel].dangerRating);
            Console.WriteLine ();
            Console.WriteLine ();
            if (planetSel == 3)
            {
                Console.WriteLine (planetTravel [4].screamingProduct);
            }
            else
            {
                Console.WriteLine ("Product Prices: ");
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