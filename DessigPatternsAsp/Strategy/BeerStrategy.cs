using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DessigPatternsAsp.Models.ViewModels;

namespace DessigPatternsAsp.Strategy
{
    public class BeerStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            //strategia para nueva cerveza
            var beer = new Beer() { 
            Name= beerVM.Name,
            Style= beerVM.Style,
            Bid = beerVM.BrandId
            };

            unitOfWork.Beers.Add(beer);
            unitOfWork.Beers.Save();
        }
    }
}
