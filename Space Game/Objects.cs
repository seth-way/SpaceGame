using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Universe
    {
        public Planet Earth = new Planet()
        { xLoc = 0.0, yLoc = 0.0, inhabitants = "Earthlings", danger = 3.5, name = "Earth" };
        public Planet ProximaCentauriB = new Planet()
        {xLoc = 2.0, yLoc = 3.75, inhabitants = "Proxima Centaurians", danger = 1.0, name = "Proxima Centauri B"};
        public Planet Planet3 = new Planet()
        {xLoc = 14.0, yLoc = -6.0, inhabitants = "Gazopazopians", danger = 2.0, name = "Gazorpazorp"};
        public Planet Planet4 = new Planet()
        {xLoc = -3.0, yLoc = -5.5, inhabitants = "Very Tired Earthlings", danger = 1.0, name = "Screaming Sun Earth"};
        public Planet Planet5 = new Planet()
        {xLoc = -20.0, yLoc = 1.5, inhabitants = "Galactic Federation", danger = 5.0, name = "Planet 35-C"};


        //Possible planet name ideas: 
        //Rick and Morty: Gazorpazorp, On a Cob Planet, Cronenberg World, Gromflom Prime, Alphabetrium, Pluto, Screaming Sun Earth
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
