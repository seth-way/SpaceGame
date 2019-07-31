using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Equations
    {
        static public double DistanceTo(Planet destination)
        {
            var changeX = destination.xLoc - Game.CurrentPlanet.xLoc;
            var changeY = destination.yLoc - Game.CurrentPlanet.yLoc;

            double distance = Math.Sqrt(Math.Abs(changeX * changeX + changeY * changeY));
            return distance;

        }

        static public double travelTime(double distance)
        {
            double years = distance / (Math.Pow(Game.NewPlayer.warpFactor, 10 /3) + Math.Pow(10 - Game.NewPlayer.warpFactor,-11/3));
            return years;
        }
    }
}
