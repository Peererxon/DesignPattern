using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DessigPatternsAsp.Controllers
{
    public class ProductDetailController : Controller
    {
        private LocalEarnFactory _localEarnFactory;
        //Dependencia LocalEarnFactory se recibe por medio de inyeccion en el constructor
        public ProductDetailController(LocalEarnFactory localEarnFactory)
        {
            _localEarnFactory = localEarnFactory;
        }


        // GET: /<controller>/
        public IActionResult Index(decimal total)
        {
            //Factories
            
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.30m, 20);

            //Productos
            var localEarn = _localEarnFactory.GetEarn();
            var foreignEarn = foreignEarnFactory.GetEarn();

            //Esto es un objeto global de asp.net donde podemos agregarle el atributo que deseemos
            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.foreignTotal = total + foreignEarn.Earn(total);
            return View();
        }
    }
}

