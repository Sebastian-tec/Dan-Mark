using static System.Console;
using System.Linq;
using System.Threading;

namespace FishTank
{
    class StockClass
    {
        
        public static List<FishClass> FishSortiment = new List<FishClass>(); // List of all fish in the aquarium
        public static List<TankClass> TankSortiment = new List<TankClass>(); // List of all fish tanks in the aquarium

        public void ViewAllFish()
        {
            Clear();

            WriteLine("Dan & Marks akvarium har følgende fisk i sortiment");
            WriteLine("**************************************************" + Environment.NewLine);

            int i = 0;
            foreach (FishClass fish in FishSortiment)
            {
                WriteLine($"Fisk nr. { i + 1 }");
                WriteLine($"Race: { fish.Name }");
                WriteLine($"Alder: { fish.Age } år");
                WriteLine($"Pris: { fish.Price } DKK");
                WriteLine($"Mad: { fish.FoodType }");
                WriteLine($"Vand: { fish.WaterType }");
                WriteLine($"Fodring: { fish.FoodCycle } timer");
                WriteLine($"------------------------");
                i++;
            }

            WriteLine(Environment.NewLine + "Ønsker du at:");
            WriteLine("1. Tilføje en fisk til soritment");
            WriteLine("2. Fjerne en fisk fra sortiment");
            WriteLine("3. Vende tilbage til hovedmenuen");

            int menuChoice;
            do
            {
                Write("Vælg en mulighed fra menuen: ");
            } while (!Int32.TryParse(ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > 3);

            switch (menuChoice)
            {
                case 1:
                    break;
                case 2:
                    RemoveFishFromSortiment();
                    break;
                case 3:
                    MenuClass menu = new MenuClass();
                    menu.MainMenu();
                    break;
            }
        }
        
        public void ViewAllFishTanks()
        {
            Clear();

            WriteLine("Dan & Marks akvarium har følgende fisketanke i sortiment");
            WriteLine("********************************************************" + Environment.NewLine);

            foreach (TankClass item in TankSortiment)
            {
                WriteLine($"ID: {item.ID}");
                WriteLine($"Størrelse: {item.TankSize} liter");
                WriteLine($"Mad: {item.FoodType}");
                WriteLine($"Vand: {item.WaterType}");
                WriteLine($"Rensecyklus: {item.CleaningCycle} timer");
                WriteLine($"Pris: {item.Price} DKK");
                Write($"Fish types: ");

                if (item.FishInTank == null || item.FishInTank.Count < 1)
                    WriteLine("Der er ikke nogen fisk i denne tank");
                else
                {
                    int numFish = 1;
                    foreach (var fish in item.FishInTank)
                    {
                        if (numFish != item.FishInTank.Count)
                            Write(fish.Name + ", ");
                        else
                            Write(fish.Name);
                        numFish++;
                    }
                    WriteLine();
                }
                WriteLine($"------------------------");
            }

            WriteLine(Environment.NewLine + "Ønsker du at:");
            WriteLine("1. Tilføje en fisk til soritment");
            WriteLine("2. Fjerne en fisk fra sortiment");
            WriteLine("3. Vende tilbage til hovedmenuen");

            int menuChoice;
            do
            {
                Write("Vælg en mulighed fra menuen: ");
            } while (!Int32.TryParse(ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > 3);

            switch (menuChoice)
            {
                case 1:
                    break;
                case 2:
                    RemoveTankFromSortiment();
                    break;
                case 3:
                    MenuClass menu = new MenuClass();
                    menu.MainMenu();
                    break;
            }
        }

        public void RemoveFishFromSortiment()
        {
            ClearCurrentConsoleLine(5);

            int fishIndex = 0;
            bool bNameFound = false;
            do
            {
                Write("Indtast navn på den fisk, du ønsker at fjerne: ");

                foreach (FishClass fish in FishSortiment)
                {
                    if (fish.Name.ToLower() == ReadLine().ToLower())
                    {
                        fishIndex = FishSortiment.IndexOf(fish);
                        bNameFound = true;
                    }
                }

            } while (!bNameFound);

            FishSortiment.RemoveAt(fishIndex);
            WriteLine("Den ønskede fisk er nu fjernet fra sortiment. Tryk en tast for at vende tilbage til oversigten...");
            ReadKey();
            ViewAllFish();
        }

        public void RemoveTankFromSortiment()
        {
            ClearCurrentConsoleLine(5);

            int i;
            do
            {
                Write("Vælg det akvarium, du ønsker at fjerne: ");
            } while (!Int32.TryParse(ReadLine(), out i));

            TankSortiment.RemoveAt(i - 1);
            WriteLine("Det ønskede akvarie er nu fjernet fra sortiment. Tryk en tast for at vende tilbage til oversigten...");
            ReadKey();
            ViewAllFishTanks();
        }

        public void AddTestFishToSortiment()
        {
            WriteLine("Tilføjer fisk...");
            Thread.Sleep(1000);
            FishClass Pirania = new FishClass("Pirania", Food.Meat, Water.Freshwater, 200.99m, 24, DateTime.Now.AddDays(-3));
            FishSortiment.Add(Pirania);
            TankClass.AddFishToTank(Pirania);
            FishClass Herring = new FishClass("Herring", Food.Flakes, Water.Saltwater, 50.00m, 12, DateTime.Now.AddDays(-1));
            FishSortiment.Add(Herring);
            TankClass.AddFishToTank(Herring);
            FishClass Trout = new FishClass("Trout", Food.Meat, Water.Saltwater, 21.99m, 24, DateTime.Now.AddDays(-32));
            FishSortiment.Add(Trout);
            TankClass.AddFishToTank(Trout);
            FishClass Goldfish = new FishClass("Goldfish", Food.Flakes, Water.Freshwater, 9.99m, 24, DateTime.Now.AddDays(-12));
            FishSortiment.Add(Goldfish);
            TankClass.AddFishToTank(Goldfish);
            FishClass Platy = new FishClass("Platy", Food.Flakes, Water.Freshwater, 19.99m, 24, DateTime.Now.AddDays(-2));
            FishSortiment.Add(Platy);
            TankClass.AddFishToTank(Platy);
            FishClass Parasema = new FishClass("Parasema", Food.Flakes, Water.Saltwater, 159.00m, 24, DateTime.Now.AddDays(-1));
            FishSortiment.Add(Parasema);
            TankClass.AddFishToTank(Parasema);
            FishClass ClownFish = new FishClass("ClownFish", Food.Flakes, Water.Saltwater, 229.00m, 24, DateTime.Now.AddDays(-2));
            FishSortiment.Add(ClownFish);
            TankClass.AddFishToTank(ClownFish);
        }

        public void AddTestAquariumsToSortiment()
        {
            WriteLine("Tilføjer akvarier...");
            Thread.Sleep(1000);

            TankClass tank1 = new TankClass(200, Food.Meat, Water.Freshwater, 48, 2999m, 24);
            TankSortiment.Add(tank1);
            TankClass tank2 = new TankClass(100, Food.Flakes, Water.Saltwater, 72, 1499m, 12);
            TankSortiment.Add(tank2);
            TankClass tank3 = new TankClass(400, Food.Meat, Water.Saltwater, 72, 8999m, 24);
            TankSortiment.Add(tank3);
            TankClass tank4 = new TankClass(1000, Food.Flakes, Water.Freshwater, 72, 19999m, 24);
            TankSortiment.Add(tank4);
        }

        public static void ReturnToMainMenu()
        {
            MenuClass menu = new MenuClass();
            WriteLine(Environment.NewLine + "Tryk en tast for at vende tilbage til hovedmenuen...");
            ReadKey();
            menu.MainMenu();
        }
        public void ClearCurrentConsoleLine(int iterations)
        {
            SetCursorPosition(0, CursorTop - iterations);

            int currentLineCursor = CursorTop;
            SetCursorPosition(0, CursorTop);
            for (int i = 0; i < iterations; i++)
            {
                WriteLine(new string(' ', BufferWidth - 1));
            }

            SetCursorPosition(0, currentLineCursor);
        }
    }
}
