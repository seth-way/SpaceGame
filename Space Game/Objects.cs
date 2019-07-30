using System;
using System.Collections.Generic;
using System.Text;

namespace Space_Game
{
    class Planet
    {
        public double xLoc, yLoc, danger;
        public string inhabitants;

        /*public Planet(double x, double y, string i, double d)
        {
            xLoc = x;
            yLoc = y;
            inhabitants = i;
            danger = d;
        }*/
        public Tuple<double, double> Location(double xLoc, double yLoc)
        {
            var location = Tuple.Create(xLoc, yLoc);
            return location;
        }

        public string Inhabitants(string inhabitants)
        {
            return inhabitants;
        }
        public double DangerRating(double danger)
        {
            return danger;
        }

    }

    class Earth : Planet
    {
        double ExLoc = 0.0;
        double yLoc = 0.0;
    }


    class Goods
    {
        public string type;
        public double price;
        public int size;
        
    }
}
