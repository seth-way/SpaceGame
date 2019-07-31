using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpaceGame
{
    class Program
    {
        static void Main (string [] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            //Bitmap image1 = new Bitmap();
            //Draw.ConsoleWriteImage(image1);
            Game MainGame = new Game();
            MainGame.RunGame();
        }
    }
}
