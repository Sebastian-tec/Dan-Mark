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
        public int Age            { get; set; }
        public Food FoodType;
        public Water WaterType;

        public FishClass(string name, Food foodType, Water waterType, Decimal price, int foodCycle, DateTime born)
        {
            Name = name;
            FoodType = foodType;
            WaterType = waterType;
            Price = price;
            FoodCycle = foodCycle;
            Born = born;
            Age = GetAge();
        }

        public int GetAge()
        {
            Age = DateTime.Now.Year - Born.Year;
            
            if (DateTime.Now.DayOfYear < Born.DayOfYear)
            {
                Age--;
            }
            
            return Age;
        }
    }
}
