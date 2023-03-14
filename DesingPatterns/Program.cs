using DesingPatterns.Factory;
using DesingPatterns.Models;
using DesingPatterns.RepositoryPattern;

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
        //invocando el nuevo contexto de entity framework
/*        using (var context = new DesingpatternContext()) {
            var beerRepository = new BeerRepository(context);
            var newBeer = new Beer() { 
                Name ="Corona",
                Style = "Pilsner"
            };
            beerRepository.Add(newBeer);
            beerRepository.Save();
            //ahora nuestra app no sabe que usa repository como fuente de datos
            foreach (var beer in beerRepository.Get())
            {
                Console.WriteLine(beer.Name);
            }
        }*/
        //contexto genrico 

        using ( var context = new DesingpatternContext())
        {
            //ahora solo cambiando el generico nos cambiamos de tabla relajao re chill
            var beerRepository = new Repository<Beer>(context);
            var beer = new Beer()
            {
                Name = "Fuller",
                Style = "Strong Ale"
            };
            beerRepository.Add(beer);
            beerRepository.Save();
        }
    }
}

