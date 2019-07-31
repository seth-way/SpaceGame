using SpaceGame;
using System;
using System.Drawing;
using System.Linq;

namespace SpaceGame
{
    class Program
    {  
        static void Main (string [] args)
        {
            //Bitmap image1 = new Bitmap();
            //Draw.ConsoleWriteImage(image1);
            Game MainGame = new Game();
            MainGame.RunGame();
        }
    }
}
