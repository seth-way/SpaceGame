using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Universe
    {
        public Planet Earth = new Planet()
        { xLoc = 0.0, yLoc = 0.0, inhabitants = "Earthlings", danger = 0.0, name = "Earth" };
        //public Planet ProximaCentauriB = new Planet();
        //public Planet Planet3 = new Planet();
        //public Planet Planet4 = new Planet();
        //public Planet Planet5 = new Planet();
    }

    class Planet
    {
        public double xLoc, yLoc, danger;
        public string inhabitants, name;

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

        public string Name()
        {
            return this.name;
        }
    }

    class Good
    {
        public string name;
        public double price;
        public int size;
        string originPlanet;
    }
}
