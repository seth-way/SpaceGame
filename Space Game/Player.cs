using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    public class Player
    {
        public string name;
        public double age = 18;
        public double cash = 100;
    }

    public class Ship
    {
        public string name;
        public int warpFactor = 1;
        public double fuel = 500;
        public int quantFur = 0;
        public int quantSeeds = 0;
        public int quantAir = 0;
        public int quantRobots = 0;
        public int quantDoors = 0;
        public double fuelPerLightYear = 100;
    }
}
