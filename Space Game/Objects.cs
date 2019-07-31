using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    class Universe
    {



        //Possible planet name ideas: 
        //Rick and Morty: Gazorpazorp, On a Cob Planet, Cronenberg World, Gromflom Prime, Alphabetrium, Pluto, Screaming Sun Earth
        //Futurama: Omicron Persei 8:, V-Giny, Nude Beach Planet, Neutral Planet, Amazonia, Decapod 10
    }

    class Planet
    {
        public double xLoc, yLoc, danger;
        public string inhabitants, name;

        public Tuple<double, double> Location ()
        {
            var location = Tuple.Create (this.xLoc, this.yLoc);
            return location;
        }

        public string Inhabitants ()
        {
            return this.inhabitants;
        }
        public double DangerRating ()
        {
            return this.danger;
        }

        public string Name ()
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

    class Products
    {
        Good MegaTreeSeeds = new Good ()
        {
            name = "MegaTreeSeeds",
            price = 0.00,
            size = 1,
            originPlanet = Universe.Earth.name;
        };
    }
}

