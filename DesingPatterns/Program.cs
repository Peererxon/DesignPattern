using DesingPatterns.Factory;

namespace DesingPatterns;
class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        //var singleton = Singleton.Singleton.Instance;
        //var singleton2 = Singleton.Singleton.Instance;
        //var log = Singleton.Log.Instance;
        //log.Save("a");
        //log.Save("hellou!");

        SaleFactory storeSaleFactory = new StoreSaleFactory(10);
        SaleFactory internetSaleFactory = new InternetSaleFactory(2);

        Isale sale1 = storeSaleFactory.GetIsale();
        sale1.Sell(15);

        Isale sale2 = internetSaleFactory.GetIsale();
        sale2.Sell(12);
    }
}

