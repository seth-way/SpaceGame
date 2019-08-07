using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class ListNavigation
    {
        public static (bool, int) scrollList(List<string> list, int cursorStart, bool finished)
        {
            finished = false;
            Console.SetCursorPosition(0, cursorStart);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($" {list[i]}");
                Console.WriteLine();
            }

            int index = 0;

            Console.SetCursorPosition(0, cursorStart);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write($" {list[index]}");
            Console.ResetColor();
            Console.SetCursorPosition(0, 6);

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < list.Count - 1)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" {list[index]}");

                            index++;

                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" {list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case ConsoleKey.UpArrow:

                        if (index > 0)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" {list[index]}");

                            index--;

                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" {list[index]}");
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
            return (finished, index);
        }

        public static int scrollList(List<string> list, int cursorStart)
        {
            Console.SetCursorPosition(0, cursorStart);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($" {list[i]}");
                Console.WriteLine();
            }

            int index = 0;

            Console.SetCursorPosition(0, cursorStart);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write($" {list[index]}");
            Console.ResetColor();
            Console.SetCursorPosition(0, 6);

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < list.Count - 1)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" {list[index]}");

                            index++;

                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" {list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case ConsoleKey.UpArrow:

                        if (index > 0)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" {list[index]}");

                            index--;

                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" {list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }
                }
            } while (cki.Key != ConsoleKey.Enter);
            return (index);
        }
    }
}
