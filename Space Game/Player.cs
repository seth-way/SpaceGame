namespace SpaceGame
{
    public class Player
    {
        public string name = "Player 1";
        public double age = 22;
        public double wallet = 1000;
        public int numOfProductsSold = 0;
        public double totalDistanceTraveled = 4.25;
        public double totalMoneyEarned = 0;
        public double totalMoneyStolen = 0;
        public int totalEnforcersThwarted = 0;
        public int totalPassedEnforcerAttacks = 0;
        public int totalFailedEnforcerAttacks = 0;
        public int currentYear = 2023;
        public int storyTracker = 1;
    }

    public class Ship
    {
        public string name = "The Meeseeks";
        public int warpFactor = 1;
        public double currentFuel = 500.00;
        public double maxFuel = 500.00;
        public int fuelFactor = 1;
        public double fuelPerLightYear = 100;
        public int fuelEfficiencyFactor = 1;
        public int currentInventory = 0;
        public int maxInventory = 50;
        public int storageFactor;
    }
}
