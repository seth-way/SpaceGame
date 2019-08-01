//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace SpaceGame
//{
//    public static class UI
//    {
//        public static int currentSelection = 0;
//        public static void UserMenu ()
//        {

//            for (int i = 0; i < Console.BufferHeight; i++)
//            {
//                if (i == 0 || i == (Console.BufferHeight - 1))
//                {
//                    Console.Clear ();

//                    if (i == 0)







//                        Console.BackgroundColor = ConsoleColor.White;
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    string menu = "|F1 - Inventory |F2 - Trade|F3 - Travel|F4 - Save|F12 - EXIT|";
//                    string line = "-";
//                    string menu2 = "Currency: Fuel: Age: Year: InvSpace: CurrentPlanet:";






//                    Console.SetCursorPosition ((((Console.BufferWidth) - menu.Length) / 2), 0);
//                    Console.Write (menu);
//                    for (int r = 0; r < Console.BufferWidth; i++)
//                    {
//                        Console.SetCursorPosition (r, 1);
//                        Console.Write (line);
//                    }
//                    for (int r = 0; r < Console.BufferWidth; i++)
//                    {
//                        Console.SetCursorPosition (r, (Console.BufferHeight - 2));
//                        Console.Write (line);
//                    }
//                    Console.SetCursorPosition ((Console.BufferWidth - menu2.Length) / 2, Console.BufferHeight - 1);
//                    Console.Write (menu2);
//                    Console.SetCursorPosition (Console.CursorLeft, 6);

//                }
//                else
//                {
//                    Console.ForegroundColor = ConsoleColor.Yellow;
//                    Console.BackgroundColor = ConsoleColor.Black;
//                }
//            }
//        }

//        public static void PrintPage (List<string> List)
//        {
//            UserMenu ();
//            int displayLength = List.Count;
//            if (displayLength + currentSelection >= List.Count)
//            {
//                displayLength = List.Count - currentSelection;
//            }
//            List<string> display = List.GetRange (currentSelection, displayLength);
//            for (int i = 0; i < displayLength; i++)
//            {
//                if (i == currentSelection)
//                {
//                    Console.ForegroundColor = ConsoleColor.Black;
//                    Console.BackgroundColor = ConsoleColor.White;
//                }
//                else if (List [i + currentSelection].StartsWith ("* /"))
//                {
//                    Console.ForegroundColor = ConsoleColor.DarkGray;
//                }

//                string elem = display [i];
//                Console.WriteLine (elem.ToString ());

//                Console.ForegroundColor = ConsoleColor.White;
//                Console.BackgroundColor = ConsoleColor.Black;
//            }
//            Console.SetCursorPosition (Console.CursorLeft, 6);
//        }
//    }
//}

