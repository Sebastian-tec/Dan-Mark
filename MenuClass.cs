using static System.Console;
using System.Threading;

namespace FishTank
{
    public class MenuClass
    {
        StockClass stock = new StockClass();

        public void MainMenu()
        {
            if (StockClass.TankSortiment.Count == 0)
            {
                stock.AddTestAquariumsToSortiment();
            }
            if (StockClass.FishSortiment.Count == 0)
            {
                stock.AddTestFishToSortiment();
            }

            Clear();

            WriteLine("Velkommen til Dan & Marks akvarium!" + Environment.NewLine);

            WriteLine("Du har nu følgende valgmuligheder");
            WriteLine(" 1. Se alle fisk");
            WriteLine(" 2. Se alle akvarier");
            WriteLine(" 3. Afslut");

            int menuChoice;
            do
            {
                Write("Indtast venligst en valgmulighed fra menuen: ");
            } while (!Int32.TryParse(ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > 3);


            switch (menuChoice)
            {
                case 1:
                    stock.ViewAllFish();
                    break;
                case 2:
                    stock.ViewAllFishTanks();
                    break;
                case 3:
                    Quit();
                    break;
            }
        }

        public void Quit()
        {
            Clear();
            WriteLine("Dan & Marks akvarium siger tak for besøget og på gensyn!");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}
