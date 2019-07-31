using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Equations
    {
        static public double DistanceTo(Planet destination)
        {
            (var x1, var y1) = Game.CurrentPlanet.Location();
            (var x2, var y2) = destination.Location();
            var changeX = x2 - x1;
            var changeY = y2 - y1;

            double distance = Math.Sqrt(Math.Abs(changeX * changeX + changeY * changeY));
            return distance;
        }
    }
}
