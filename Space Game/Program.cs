using System;
using System.Windows.Forms;

namespace SpaceGame
{
    class Program
    {
        static void Main (string [] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Game MainGame = new Game();
            MainGame.RunGame();
        }
    }
}
