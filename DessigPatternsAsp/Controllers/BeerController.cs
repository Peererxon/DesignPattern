using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DessigPatternsAsp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DessigPatternsAsp.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = from d in _unitOfWork.Beers.Get()
                                               select new BeerViewModel()
                                               {
                                                   Id = d.BeerId,
                                                   Name = d.Name,
                                                   Style = d.Style,
                                               };
            return View("Index", beers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var brands = _unitOfWork.Brands.Get();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
            return View();
        }

        [HttpPost] 
        public IActionResult Add(FormBeerViewModel beerVM)
        {
            if (!ModelState.IsValid)
            {
                var brands = _unitOfWork.Brands.Get();
                ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
                return View("Add", beerVM);
            }

            var beer = new Beer();
            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;
            //si no se ha seleccionado se crea, sino se usa la seleccionada
            if (beerVM.BrandId == null) {
                var brand = new Brand();
                brand.Name = beerVM.OtherBrand;
                // se debe cambiar el modelo de beer y no usar string
                brand.BrandId = Guid.NewGuid();
                //aqui debe de ser el brand.ID que es un GUI
                beer.Bid = brand.BrandId;//brand.BrandId;

                _unitOfWork.Brands.Add(brand);
            } else
            {
                beer.Bid= beerVM.BrandId;
            }

            _unitOfWork.Beers.Add(beer);
            _unitOfWork.Save(); // con esto hace una sola conexion en lugar de llamar n veces a la db

            return RedirectToAction("Index");

        }
    }
}
