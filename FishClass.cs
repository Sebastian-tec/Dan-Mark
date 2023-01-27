namespace FishTank
{
    public enum Food { Meat, Flakes };
    public enum Water { Saltwater, Freshwater };
    class FishClass
    {
        public string Name        { get; set; } // Type of fish
        public Decimal Price      { get; set; }
        public int FoodCycle      { get; set; } // Hours between feedings
        public DateTime Born      { get; set; } 
        public double Age         { get; set; }
        public Food FoodType;
        public Water WaterType;

        public FishClass(string name, Food foodType, Water waterType, Decimal price, DateTime born)
        {
            Name = name;
            FoodType = foodType;
            WaterType = waterType;
            Price = price;
            FoodCycle = TankClass.GetFoodCycle(foodType);
            Born = born;
            Age = GetAge();
        }

        public double GetAge()
        {
            Age = (DateTime.Now - Born).TotalDays;
            return Age;
        }
        public string GetAgeInfo(DateTime born)
        {
            double daysAlive = (DateTime.Now - born).TotalDays;
            
            if (daysAlive < 365)
            {
                if (daysAlive < 30)
                    return $"{daysAlive:N0} dag(e)";
                else
                    return $"{daysAlive / 30:N0} måned(er)";
            }
            else
            {
                return $"{daysAlive / 365:N0} år";
            }
        }
    }
}
