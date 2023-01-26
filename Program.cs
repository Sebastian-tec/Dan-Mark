namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            StockClass stock = new StockClass();
            stock.AddTestFishToSortiment();
            stock.AddTestAquariumsToSortiment();

            MenuClass menuClass = new MenuClass();
            menuClass.MainMenu();
        }
    }
}