using DesingPatterns.Factory;
using DesingPatterns.Models;
using DesingPatterns.RepositoryPattern;
using DesingPatterns.Strategy;
using DesingPatterns.UnitOfWork;
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

        /*        using ( var context = new DesingpatternContext())
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
                }*/

        /*        using (var context = new DesingpatternContext())
                {
                    var unitOfWork = new UnitOfWork.UnitOfWork(context);

                    var beers = unitOfWork.Beers;
                    var beer = new Beer()
                    {
                        Name = "Fuller",
                        Style = "Porter"
                    };
                    beers.Add(beer);

                    var brands = unitOfWork.Brands;
                    var brand = new Brand()
                    {
                        Name = "Fuller"
                    };
                    brands.Add(brand);

                    unitOfWork.Save(); // con esto se mandan todas las entidades en una sola peticion
                }*/
        // cambio la estrategia en tiempo de ejecucion
        var context = new Context( new MotoStrategy());
        context.Run();
        context.Strategy = new CarStrategy();
        context.Run();
        context.Strategy = new BicycleStrategy();
        context.Run();
    }
}

