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
            Game MainGame = new Game();
            MainGame.RunGame();
        }
    }
}
