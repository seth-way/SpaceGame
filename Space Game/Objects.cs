using System;
using System.Collections.Generic;

namespace SpaceGame
{
    public class Universe
    {

        // things to change if adding a new planet: UI.TravelMenu planet array length and add the planet to the list + create planet display function

        public static readonly Planet Earth = new Planet()
        {
            xLoc = 0.0,
            yLoc = 0.0,
            inhabitants = "Earthlings",
            dangerRating = 5.0,
            name = "Earth",
            description = StoryLine.earthDescr,
            imageFile = "Earth.bmp"
        };

        public static readonly Planet ProximaCentauriB = new Planet()
        {
            xLoc = 2.0,
            yLoc = 3.75,
            inhabitants = "Proxima Centaurians",
            dangerRating = 2.0,
            name = "Proxima Centauri B",
            description = StoryLine.proximaDescr,
            imageFile = "ProximaB.bmp"
        };

        public static readonly Planet Gazorpazorp = new Planet ()
        {
            xLoc = 14.0,
            yLoc = -6.0,
            inhabitants = "Gazorpazorp",
            dangerRating = 6.0,
            name = "Gazorpazorp",
            description = StoryLine.gazorpDescr,
            imageFile = "Gazorpazorp.bmp"
        };

        public static readonly Planet ScreamingSun = new Planet()
        {
            xLoc = -3.0,
            yLoc = -5.5,
            inhabitants = "Tired Earthlings",
            dangerRating = 1.5,
            name = "Screaming Sun Earth",
            description = StoryLine.screamingSunDescr,
            imageFile = "ScreamingSun.bmp"
        };

        public static readonly Planet C35 = new Planet()
        { xLoc = -20.0,
            yLoc = 1.5,
            inhabitants = "Galactic Federation",
            dangerRating = 5.0,
            name = "35-C",
            description = StoryLine.c35Descr,
            imageFile = "C35.bmp"
        };

        public static readonly Planet GromflomPrime = new Planet()
        {
            xLoc = -1,
            yLoc = 32,
            inhabitants = "Genetically Engineered Gromflomites",
            dangerRating = 7.0,
            name = "Gromflom Prime",
            description = StoryLine.gromDescr,
            imageFile = "GromflomPrime.bmp"
        };

        public static Planet[] planetTravel = { Earth, ProximaCentauriB, Gazorpazorp, ScreamingSun, C35, GromflomPrime };
        public static Market[] planetMarket = { Products.earthPrices, Products.proximaPrices, Products.gazorpazorpPrices, Products.screamingPrices, Products.c35Prices, Products.gromflomPrices };
        public static string[] stringMarket = { "Canned Earth Air: #", "Proxima Centaurian Fur: #", "Gazorpian Service Robots: #", "Real Fake Doors: #", "Mega Tree Seeds: #" };

    }

    public class Planet
    {
        public double xLoc, yLoc, dangerRating;
        public string inhabitants, name;
        public string description = " ";
        public string imageFile;
        public string soundClip;
    }

    public class WarpFactor
    {
        public int Warp;
    }

    public class Good
    {
        public string description, name, unit;
        public double price;
        public int size, onHand;
        public Planet originPlanet;
    }

    public class Market
    {
        public double air, fur, robot, doors, seeds;
    }
 
    public class Products
    {
        static public Good CannedAir = new Good()
        {
            name = "Canned Earth Air",
            price = 1.00,
            size = 1,
            originPlanet = Universe.Earth,
            description = "A can of air from Earth. While it seems like an ordinary item to you, other" +
            "species that live in atmospheres different to Earth use this as a recreational drug.",
            onHand = 0,
            unit = "Can(s) of Earth Air"
        };

        static public Good CentaurianFur = new Good()
        {
            name = "Proxima Centaurian Fur",
            price = 1.00,
            size = 1,
            originPlanet = Universe.ProximaCentauriB,
            description = "The Centaurs of Proxima are reknowned for their soft yet strong fur. Although none of" +
            "them actually have any visible fur. You try not to think about it.",
            onHand = 0,
            unit = "Centaurian Fur pelt(s)"
        };

        static public Good ServiceRobot = new Good()
        {
            name = "Gazorpian Service Robots",
            price = 1.00,
            size = 1,
            originPlanet = Universe.Gazorpazorp,
            description = "A robot from the planet Gazorpazorp. You don't understand it's purpose," +
            "but other species seem to be really eager to buy it.",
            onHand = 0,
            unit = "Gazorpian Service Robot(s)"

        };

        static public Good RealFakeDoors = new Good ()
        {
            name = "Real Fake Doors",
            price = 1.00,
            size = 1,
            originPlanet = Universe.GromflomPrime,
            description = "When you asked the salesman how he got to Gromflom he just blankly stared at the ground" +
            "muttering something, you were barely able to hear the last bit of his explanation; 'The door was real" +
            "but it wasn't real fake...' The doors are worthless. Maybe someone will use them for firewood.",
            onHand = 0,
            unit = "Real Fake Door(s)"
        };

        static public Good MegaTreeSeeds = new Good ()
        {
            name = "Mega Tree Seeds",
            price = 1.00,
            size = 1,
            originPlanet = Universe.C35,
            description = "A highly controlled seed that was smuggled out of Planet 35-C. Causes the" +
            "consumer to have temporary super intelligence. Don't ask how they were smuggled out.",
            onHand = 0,
            unit = "Mega Tree Seed(s)"
        };

        //If we add more Goods, be sure to update the productList and the UI tradeMenu.

        static public List<Good> productList = new List<Good>() {CannedAir, CentaurianFur, ServiceRobot, RealFakeDoors, MegaTreeSeeds};

        static public Market earthPrices = new Market()
        {
            air = Math.Round(CannedAir.price * (1 + Equations.DistanceBetween(Universe.Earth, CannedAir.originPlanet)) * Universe.Earth.dangerRating, 2),
            fur = Math.Round(CentaurianFur.price * (1 + Equations.DistanceBetween(Universe.Earth, CentaurianFur.originPlanet)) * Universe.Earth.dangerRating, 2),
            robot = Math.Round(ServiceRobot.price * (1 + Equations.DistanceBetween(Universe.Earth, ServiceRobot.originPlanet)) * Universe.Earth.dangerRating, 2),
            doors = Math.Round(RealFakeDoors.price * (1 + Equations.DistanceBetween(Universe.Earth, RealFakeDoors.originPlanet)) * Universe.Earth.dangerRating, 2),
            seeds = Math.Round(MegaTreeSeeds.price * (1 + Equations.DistanceBetween(Universe.Earth, MegaTreeSeeds.originPlanet)) * Universe.Earth.dangerRating, 2)
        };

        static public Market proximaPrices = new Market()
        {
            air = Math.Round(CannedAir.price * (1 + Equations.DistanceBetween(Universe.ProximaCentauriB, CannedAir.originPlanet)) * Universe.ProximaCentauriB.dangerRating, 2),
            fur = Math.Round(CentaurianFur.price * (1 + Equations.DistanceBetween(Universe.ProximaCentauriB, CentaurianFur.originPlanet)) * Universe.ProximaCentauriB.dangerRating, 2),
            robot = Math.Round(ServiceRobot.price * (1 + Equations.DistanceBetween(Universe.ProximaCentauriB, ServiceRobot.originPlanet)) * Universe.ProximaCentauriB.dangerRating, 2),
            doors = Math.Round(RealFakeDoors.price * (1 + Equations.DistanceBetween(Universe.ProximaCentauriB, RealFakeDoors.originPlanet)) * Universe.ProximaCentauriB.dangerRating, 2),
            seeds = Math.Round(MegaTreeSeeds.price * (1 + Equations.DistanceBetween(Universe.ProximaCentauriB, MegaTreeSeeds.originPlanet)) * Universe.ProximaCentauriB.dangerRating, 2)
        };

        static public Market gazorpazorpPrices = new Market()
        {
            air = Math.Round(CannedAir.price * (1 + Equations.DistanceBetween(Universe.Gazorpazorp, CannedAir.originPlanet)) * Universe.Gazorpazorp.dangerRating, 2),
            fur = Math.Round(CentaurianFur.price * (1 + Equations.DistanceBetween(Universe.Gazorpazorp, CentaurianFur.originPlanet)) * Universe.Gazorpazorp.dangerRating, 2),
            robot = Math.Round(ServiceRobot.price * (1 + Equations.DistanceBetween(Universe.Gazorpazorp, ServiceRobot.originPlanet)) * Universe.Gazorpazorp.dangerRating, 2),
            doors = Math.Round(RealFakeDoors.price * (1 + Equations.DistanceBetween(Universe.Gazorpazorp, RealFakeDoors.originPlanet)) * Universe.Gazorpazorp.dangerRating, 2),
            seeds = Math.Round(MegaTreeSeeds.price * (1 + Equations.DistanceBetween(Universe.Gazorpazorp, MegaTreeSeeds.originPlanet)) * Universe.Gazorpazorp.dangerRating, 2)
        };

        static public Market screamingPrices = new Market()
        {
            air = Math.Round(CannedAir.price * (1 + Equations.DistanceBetween(Universe.ScreamingSun, CannedAir.originPlanet)) * Universe.ScreamingSun.dangerRating, 2),
            fur = Math.Round(CentaurianFur.price * (1 + Equations.DistanceBetween(Universe.ScreamingSun, CentaurianFur.originPlanet)) * Universe.ScreamingSun.dangerRating, 2),
            robot = Math.Round(ServiceRobot.price * (1 + Equations.DistanceBetween(Universe.ScreamingSun, ServiceRobot.originPlanet)) * Universe.ScreamingSun.dangerRating, 2),
            doors = Math.Round(RealFakeDoors.price * (1 + Equations.DistanceBetween(Universe.ScreamingSun, RealFakeDoors.originPlanet)) * Universe.ScreamingSun.dangerRating, 2),
            seeds = Math.Round(MegaTreeSeeds.price * (1 + Equations.DistanceBetween(Universe.ScreamingSun, MegaTreeSeeds.originPlanet)) * Universe.ScreamingSun.dangerRating, 2)
        };

        static public Market c35Prices = new Market()
        {
            air = Math.Round(CannedAir.price * (1 + Equations.DistanceBetween(Universe.C35, CannedAir.originPlanet)) * Universe.C35.dangerRating, 2),
            fur = Math.Round(CentaurianFur.price * (1 + Equations.DistanceBetween(Universe.C35, CentaurianFur.originPlanet)) * Universe.C35.dangerRating, 2),
            robot = Math.Round(ServiceRobot.price * (1 + Equations.DistanceBetween(Universe.C35, ServiceRobot.originPlanet)) * Universe.C35.dangerRating, 2),
            doors = Math.Round(RealFakeDoors.price * (1 + Equations.DistanceBetween(Universe.C35, RealFakeDoors.originPlanet)) * Universe.C35.dangerRating, 2),
            seeds = Math.Round(MegaTreeSeeds.price * (1 + Equations.DistanceBetween(Universe.C35, MegaTreeSeeds.originPlanet)) * Universe.C35.dangerRating, 2)
        };

        static public Market gromflomPrices = new Market()
        {
            air = Math.Round(CannedAir.price * (1 + Equations.DistanceBetween(Universe.GromflomPrime, CannedAir.originPlanet)) * Universe.GromflomPrime.dangerRating, 2),
            fur = Math.Round(CentaurianFur.price * (1 + Equations.DistanceBetween(Universe.GromflomPrime, CentaurianFur.originPlanet)) * Universe.GromflomPrime.dangerRating, 2),
            robot = Math.Round(ServiceRobot.price * (1 + Equations.DistanceBetween(Universe.GromflomPrime, ServiceRobot.originPlanet)) * Universe.GromflomPrime.dangerRating, 2),
            doors = Math.Round(RealFakeDoors.price * (1 + Equations.DistanceBetween(Universe.GromflomPrime, RealFakeDoors.originPlanet)) * Universe.GromflomPrime.dangerRating, 2),
            seeds = Math.Round(MegaTreeSeeds.price * (1 + Equations.DistanceBetween(Universe.GromflomPrime, MegaTreeSeeds.originPlanet)) * Universe.GromflomPrime.dangerRating, 2)
        };

    }
}

