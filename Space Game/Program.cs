using System;

namespace SpaceGame
{
    class Program
    {
        public static readonly int windowWidth = Console.LargestWindowWidth;
        public static readonly int windowHeight = Console.LargestWindowHeight;
        static void Main (string [] args)
        {
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.SetBufferSize(windowWidth, windowHeight);
            Console.CursorVisible = false;
            //Console.WriteLine ("What is your name?");
            //string playerName = Console.ReadLine ();
            //Console.Title = playerName + ": A Life Well Lived";
            Game MainGame = new Game();
            MainGame.RunGame();
        }
    }
}
