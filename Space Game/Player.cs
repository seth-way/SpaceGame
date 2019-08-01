using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    public class Player
    {
        public string name;
        public double age = 18;
        public double wallet = 100;
    }

    public class Ship
    {
        public string name;
        public int warpFactor = 1;
        public double fuel = 500;
        public double fuelPerLightYear = 100;
        public double currentInventory = 0;
        public double maxInventory = 50;
    }
}
