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
        public static readonly Planet Gazorpazorp = new Planet ()
        { xLoc = 14.0, yLoc = -6.0, inhabitants = "Gazorpazorp", dangerRating = 6.0 , name = "Gazorpazorp" };
        public static readonly Planet ScreamingSun = new Planet ()
        { xLoc = -3.0, yLoc = -5.5, inhabitants = "Tired Earthlings", dangerRating = 1.5, name = "Screaming Sun Earth" };
        public static readonly Planet C35 = new Planet ()
        { xLoc = -20.0, yLoc = 1.5, inhabitants = "Galactic Federation", dangerRating = 5.0, name = "35-C" };
        public static readonly Planet GromflomPrime = new Planet ()
        { xLoc = 0, yLoc = 0, inhabitants = "Genetically Engineered Gromflomites", dangerRating = 7.0, name = "Gromflom Prime"};

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
        public string description;
        public string name;
        public double price;
        public int size;
        public string originPlanet;
    }

    public class Products
    {
       static public Good CannedAir = new Good ()
        {
            name = "Canned Earth Air",
            price = 0.00,
            size = 1,
            originPlanet = Universe.Earth.name,
            description = "A can of air from Earth. While it seems like an ordinary item to you, other" +
            "species that live in atmospheres different to Earth use this as a recreational drug."
        };

        static public Good CentaurianFur = new Good ()
        {
            name = "Proxima Centaurian Fur",
            price = 1.00,
            size = 1,
            originPlanet = Universe.ProximaCentauriB.name,
            description = "The Centaurs of Proxima are reknowned for their soft yet strong fur. Although none of" +
            "them actually have any visible fur. You try not to think about it."
        };

        static public Good ServiceRobot = new Good ()
        {
            name = "Gazorpian Service Robot",
            price = 1.00,
            size = 1,
            originPlanet = Universe.Gazorpazorp.name,
            description = "A robot from the planet Gazorpazorp. You don't understand it's purpose," +
            "but other species seem to be really eager to buy it."
        };

        static public Good RealFakeDoors = new Good ()
        {
            name = "Real Fake Doors",
            price = 500.00,
            size = 1,
            originPlanet = Universe.GromflomPrime.name,
            description = "When you asked the salesman how he got to Gromflom he just blankly stared at the ground" +
            "muttering something, you were barely able to hear the last bit of his explanation; 'The door was real" +
            "but it wasn't real fake...' The doors are worthless. Maybe someone will use them for firewood."
        };

        static public Good MegaTreeSeeds = new Good ()
        {
            name = "Mega Tree Seeds",
            price = 0.00,
            size = 1,
            originPlanet = Universe.C35.name,
            description = "A highly controlled seed that was smuggled out of Planet 35-C. Causes the" +
            "consumer to have temporary super intelligence. Don't ask how they were smuggled out."
        };
    }
}

