using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DessigPatternsAsp.Models.ViewModels;

namespace DessigPatternsAsp.Strategy
{
    public class BeerWithBrandStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer()
            {
                Name = beerVM.Name,
                Style = beerVM.Style,
                
            };

            var brand = new Brand()
            {
                Name = beerVM.OtherBrand,
                BrandId = Guid.NewGuid(),
            };
            //asignando el brandID a la nueva cerveza con el nuevo valor que generamos para el brand
            beer.Bid = brand.BrandId;
            unitOfWork.Brands.Add(brand);
            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();// con esto hace una sola conexion en lugar de llamar n veces a la db
        }
    }
}
