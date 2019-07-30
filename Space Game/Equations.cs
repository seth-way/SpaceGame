using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Equations
    {
        static double DistanceTo(int changeX, int changeY)
        {
            double distance = Math.Sqrt(changeX * changeX + changeY * changeY);
            return distance;
        }
    }
}
