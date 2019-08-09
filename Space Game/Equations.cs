using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Equations
    {
        static public double DistanceTo(Planet destination, Planet CurrentPlanet)
        {
            var changeX = destination.xLoc - CurrentPlanet.xLoc;
            var changeY = destination.yLoc - CurrentPlanet.yLoc;

            double distance = Math.Round(Math.Sqrt(Math.Abs(changeX * changeX + changeY * changeY)), 2);
            return distance;

        }

        static public double TravelTime(double distance)
        {
            double years = Math.Round(distance / (Math.Pow(Game.NewShip.warpFactor, 10 /3) + Math.Pow(10 - Game.NewShip.warpFactor,-11/3)), 3);
            return years;
        }

        static public double DistanceBetween(Planet A, Planet B)
        {
            var changeX = A.xLoc - B.xLoc;
            var changeY = A.yLoc - B.yLoc;

            double distance = Math.Round(Math.Sqrt(Math.Abs(changeX * changeX + changeY * changeY)), 2);
            return distance;
        }

        static public double UpgradeCost(int factor)
        {
            double cost = 1000 + ((factor - 1) * 500);
            return cost;
        }
    }
}
