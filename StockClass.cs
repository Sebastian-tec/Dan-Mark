using System.Threading.Tasks;
using static System.Console;

namespace FishTank
{
    class StockClass
    {
        public static List<FishClass> FishSortiment = new List<FishClass>(); // List of all fish in the aquarium
        public static List<TankClass> TankSortiment = new List<TankClass>(); // List of all fish tanks in the aquarium

        public void ViewAllFish()
        {
            WriteLine("Dan & Marks akvarium har følgende fisk i sortiment");
            WriteLine("**************************************************" + Environment.NewLine);

            int i = 0;
            foreach (FishClass fish in FishSortiment)
            {
                WriteLine($"Fisk nr. { i + 1 }");
                WriteLine($"Race: { fish.Name }");
                WriteLine($"Alder: { fish.Age }");
                WriteLine($"Pris: { fish.Price }");
                WriteLine($"Mad: { fish.FoodType }");
                WriteLine($"Vand: { fish.FoodCycle }");
                i++;
            }
        }
        
        public void ViewAllFishTanks()
        {
            WriteLine("Dan & Marks akvarium har følgende fisketanke i sortiment");
            WriteLine("**************************************************" + Environment.NewLine);

            foreach (TankClass item in TankSortiment)
            {
                WriteLine($"ID: {item.ID}");
                WriteLine($"Størrelse: {item.TankSize}");
                WriteLine($"Mad: {item.FoodType}");
                WriteLine($"Vand: {item.WaterType}");
                WriteLine($"Rensecyklus: {item.CleaningCycle}");
                WriteLine($"Pris: {item.Price}");
            }
        }

        public void AddTestFishToSortiment()
        {
            FishClass fish1 = new FishClass("Pirania", Food.Meat, Water.Freshwater, 39.99m, 24, DateTime.Now.AddDays(-3), 1);
            FishSortiment.Add(fish1);
            FishClass fish2 = new FishClass("Herring", Food.Flakes, Water.Saltwater, 11.99m, 12, DateTime.Now.AddDays(-1), 2);
            FishSortiment.Add(fish2);
            FishClass fish3 = new FishClass("Trout", Food.Meat, Water.Saltwater, 21.99m, 24, DateTime.Now.AddDays(-32), 3);
            FishSortiment.Add(fish3);
            FishClass fish4 = new FishClass("Sunfish", Food.Meat, Water.Saltwater, 199.99m, 24, DateTime.Now.AddDays(-56), 3);
            FishSortiment.Add(fish4);
        }

        public void AddTestAquariumsToSortiment()
        {
            TankClass tank1 = new TankClass(200, Food.Meat, Water.Freshwater, 48, 2999m, 24);
            TankSortiment.Add(tank1);
            TankClass tank2 = new TankClass(100, Food.Flakes, Water.Saltwater, 72, 1499m, 12);
            TankSortiment.Add(tank2);
            TankClass tank3 = new TankClass(400, Food.Meat, Water.Saltwater, 72, 8999m, 24);
            TankSortiment.Add(tank3);
        }
    }
}
