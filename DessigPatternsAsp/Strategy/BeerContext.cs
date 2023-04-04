using DesignPatterns.Repository;
using DessigPatternsAsp.Models.ViewModels;

namespace DessigPatternsAsp.Strategy
{
    public class BeerContext
    {
        private IBeerStrategy _strategy;

        public IBeerStrategy Strategy
        {
            set 
            {
                _strategy = value;
            }
        }

        public BeerContext(IBeerStrategy strategy)
        {
            // pueden ser ambos casos de estrategia, no nos importa
            _strategy = strategy;
        }

        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitofWork)
        {
            //nose como lo haces, hazlo
            _strategy.Add(beerVM, unitofWork);
        }
    }
}
