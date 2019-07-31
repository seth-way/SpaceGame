using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Universe
    {
        public Planet Earth = new Planet()
        { xLoc = 0.0, yLoc = 0.0, inhabitants = "Earthlings", danger = 0.0, name = "Earth" };
        public Planet ProximaCentauriB = new Planet()
        {xLoc = 2.0, yLoc = 3.75, inhabitants = "ProximaCentaurians", danger = 0.0, name = "Proxima Centauri B"};
        public Planet Planet3 = new Planet()
        {xLoc = 14.0, yLoc = -6.0, inhabitants = "Gazopazop", danger = 0.0, name = "Gazopazop"};
        public Planet Planet4 = new Planet()
        {xLoc = -3.0, yLoc = -5.5, inhabitants = "Planet 4ans", danger = 0.0, name = "Screaming Sun Earth"};
        public Planet Planet5 = new Planet()
        {xLoc = -20.0, yLoc = 1.5, inhabitants = "Planet 5ans", danger = 0.0, name = "Planet 5"};


        //Possible planet name ideas: 
        //Rick and Morty: Gazopazop, On a Cob Planet, Cronenberg World, Gromflom Prime, Alphabetrium, Pluto, Screaming Sun Earth
        //Futurama: Omicron Persei 8:, V-Giny, Nude Beach Planet, Neutral Planet, Amazonia, Decapod 10
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
        public string type;
        public double price;
        public int size;
        
    }
}
