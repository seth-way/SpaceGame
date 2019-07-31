using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    public class Universe
    {
        public static readonly Planet Earth = new Planet ()
        { xLoc = 0.0, yLoc = 0.0, inhabitants = "Earthlings", dangerRating = 5.0, name = "Earth" };
        public static readonly Planet ProximaCentauriB = new Planet ()
        { xLoc = 2.0, yLoc = 3.75, inhabitants = "Proxima Centaurians", dangerRating = 2.0, name = "Proxima Centauri B" };
        public static readonly Planet Planet3 = new Planet ()
        { xLoc = 14.0, yLoc = -6.0, inhabitants = "Gazorpazorp", dangerRating = 6.0 , name = "Gazorpazorp" };
        public static readonly Planet Planet4 = new Planet ()
        { xLoc = -3.0, yLoc = -5.5, inhabitants = "Tired Earthlings", dangerRating = 1.5, name = "Screaming Sun Earth" };
        public static readonly Planet C35 = new Planet ()
        { xLoc = -20.0, yLoc = 1.5, inhabitants = "Galactic Federation", dangerRating = 5.0, name = "35-C" };

        //Possible planet name ideas: 
        //Rick and Morty: Gazopazop, On a Cob Planet, Cronenberg World, Gromflom Prime, Alphabetrium, Pluto, Screaming Sun Earth
        //Futurama: Omicron Persei 8:, V-Giny, Nude Beach Planet, Neutral Planet, Amazonia, Decapod 10
    }

    public class Planet
    {
        public double xLoc, yLoc, dangerRating;
        public string inhabitants, name;

    }

    public class WarpFactor
    {
        public int Warp;
    }

    public class Good
    {
        public string name;
        public double price;
        public int size;
        public string originPlanet;
    }

    public class Products
    {
        public Good MegaTreeSeeds = new Good ()
        {
            name = "MegaTreeSeeds",
            price = 0.00,
            size = 1,
            originPlanet = Universe.C35.name
        };

        public Good CentaurianFur = new Good ()
        {
            name = "Proxima Centaurian Fur",
            price = 0.00,
            size = 1,
            originPlanet = Universe.ProximaCentauriB.name
        };
    }
}

