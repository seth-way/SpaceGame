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
            Universe GameUniverse = new Universe();

            Console.WriteLine($"{GameUniverse.Earth.Inhabitants()}");
        }
        void DrawBmp(string path)
        {
            Bitmap image1 = new Bitmap (path);
            Draw.ConsoleWriteImage (image1);
        }
    }
}
