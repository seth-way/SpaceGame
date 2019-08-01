using System;
//using System.Windows.Forms;

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
            //SendKeys.Send ("{F11}");

            UI.UserMenu ();

            //System.Threading.Thread.Sleep (3000);

            //Game MainGame = new Game();
            //MainGame.RunGame();
        }
    }
}
