using System;
using System.Drawing;
using System.Linq;

namespace SpaceGame
{
    class Program
    {
        static void Main (string [] args)
        {
            Bitmap image1 = new Bitmap ("C:\\Users\\justi\\OneDrive\\Desktop\\Moon Abstract.bmp");
            Draw.ConsoleWriteImage (image1);
            Console.WriteLine (Planet.test);
        }
    }
}
