using System;

namespace SpaceGame
{
    class Program
    {
        public static readonly int windowWidth = Console.LargestWindowWidth;
        public static readonly int windowHeight = Console.LargestWindowHeight;
        static void Main (string [] args)
        {
            Console.SetWindowSize (windowWidth, windowHeight);
            Console.SetBufferSize (windowWidth, windowHeight);
            //Console.CursorVisible = false;
            //Console.WriteLine("What is your name?");
            //string playerName = Console.ReadLine();
            //Console.Title = playerName + ": A Life Well Lived";
            //Console.Read();
            //System.Threading.Thread.Sleep (3000); //this is so you can make the window fullscreen before starting the game

            Game MainGame = new Game ();
            MainGame.RunGame ();
        }
    }
}
