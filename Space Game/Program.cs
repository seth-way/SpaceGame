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
            Console.CursorVisible = false;
            //Console.OutputEncoding = System.Text.Encoding.UTF8; // tried using unicode characters...... it didn't work

            //System.Threading.Thread.Sleep (3000); //this is so you can make the window fullscreen before starting the game

            Game MainGame = new Game ();
            MainGame.RunGame ();
        }
    }
}
