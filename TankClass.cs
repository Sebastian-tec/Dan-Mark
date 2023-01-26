using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank
{
    class TankClass
    {
        public int ID                     { get; set; }
        public double TankSize            { get; set; } // Størrelsen på akvariet i kubikmeter
        public Food FoodType;
        public Water WaterType;
        public int CleaningCycle          { get; set; } // int, som i procent angiver en grænse for, hvor beskidt akvariet kan blive
        public Decimal Price              { get; set; }
        public int FoodCycle              { get; set; }
        public List<FishClass> FishInTank { get; set; }
        public bool IsClean               { get; set; }
        public bool FeedFish              { get; set; }
        private static int id;

        public TankClass(double tankSize, Food foodType, Water waterType, int cleaningCycle, Decimal price, int foodCycle)
        {
            ID = Interlocked.Increment(ref id);
            TankSize = tankSize;
            FoodType = foodType;
            WaterType = waterType;
            CleaningCycle = cleaningCycle;
            Price = price;
            FoodCycle = foodCycle;
            IsClean = CleanTank();
            FeedFish = FishFeeded();
        }

        public bool CleanTank()
        {
            DateTime currenttime = DateTime.Now;
            if (WaterType == Water.Saltwater)
            {
                // Saltvandsakvarium
                if (DateTime.Today.AddHours(72) > currenttime)
                {
                    // Akvariet er ikke blevet renset i 72 timer
                    // Der skal renses
                    return false;
                }

                // Akvariet er blevet renset i mindre end 72 timer siden
                // Der skal ikke renses
                return true;
            }
            else
            {
                // Ferskvandsakvarium
                if (DateTime.Today.AddHours(48) > currenttime)
                {
                    // Akvariet er ikke blevet renset i 48 timer
                    // Der skal renses
                    return false;
                }

                // Akvariet er blevet renset i mindre end 48 timer siden
                // Der skal ikke renses
                return true;
            }
        }
        
        public bool FishFeeded()
        {
            // Hvis fiskene skal fodres med kød
            if (FoodType == Food.Flakes)
            {
                // Hvis fodringstidspunkt er over det nuværende tidspunkt
                if (DateTime.Today.AddHours(FoodCycle) > DateTime.Now)
                {
                    // Der skal fodres
                    return true;
                }
                // Der skal ikke fodres
                return false;
            }
            else
            {
                // Hvis fodringstidspunkt er over det nuværende tidspunkt
                if (DateTime.Today.AddHours(FoodCycle) > DateTime.Now)
                {
                    // Der skal fodres
                    return true;
                }
                // der skal fodres
                return false;
            }
        }

        public void AddFish(FishClass fish, TankClass tank)
        {
            tank.FishInTank.Add(fish);
        }
        
        public void RemoveFish(int listIndex)
        {
            FishInTank.RemoveAt(listIndex);
        }
    }
}
