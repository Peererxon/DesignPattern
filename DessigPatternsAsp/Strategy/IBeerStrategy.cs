using DesignPatterns.Repository;
using DessigPatternsAsp.Models.ViewModels;

namespace DessigPatternsAsp.Strategy
{
    public interface IBeerStrategy
    {

        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork);
    }
}
