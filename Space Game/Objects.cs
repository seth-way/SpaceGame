using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Universe
    {
        public Planet Earth = new Planet() { xLoc = 0.0, yLoc = 0.0, inhabitants = "Earthlings", danger = 0.0 };
        //public Planet ProximaCentauri1 = new Planet();
        //public Planet Planet3 = new Planet();


    }

    class Planet
    {
        public double xLoc, yLoc, danger;
        public string inhabitants;

        //Planet(double xLoc, double yLoc, string inhabitants, double danger)
       // {
        //    this.xLoc = xLoc;
        //    this.yLoc = yLoc;
        //    this.inhabitants = inhabitants;
        //    this.danger = danger;
        //}
        public Tuple<double, double> Location()
        {
            var location = Tuple.Create(this.xLoc, this.yLoc);
            return location;
        }

        public string Inhabitants()
        {
            return this.inhabitants;
        }
        public double DangerRating()
        {
            return this.danger;
        }

    }

    class Goods
    {
        public string type;
        public double price;
        public int size;
        
    }
}
