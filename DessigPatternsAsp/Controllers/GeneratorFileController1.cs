using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Tools.Generator;

namespace DessigPatternsAsp.Controllers
{
    public class GeneratorFileController1 : Controller
    {
        private IUnitOfWork _unitOfWork;
        private GeneratorConcreteBuilder _generatorConcreteBuilder;

        public GeneratorFileController1(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generatorConcreteBuilder)
        {
            _unitOfWork = unitOfWork;
            _generatorConcreteBuilder = generatorConcreteBuilder;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateFile(int optionFile) {
            try
            {
                Console.WriteLine("Llamando CreateFile");
                var beers = _unitOfWork.Beers.Get();
                List<string> content = beers.Select(d => d.Name).ToList();
                // se agrega el random para que no existan 2 archivos con el mismo nombre y se sobreescriban
                string path = "file" + DateTime.Now.Ticks + new Random().Next(1000) + ".txt";
                var director = new GeneratorDirector(_generatorConcreteBuilder);

                //Segun la opcion generamos el archivo de una forma u otra para hacer uso de builder
                if (optionFile== 1)
                    director.CreateSimpleJsonGenerator(content, path);
                else
                    director.CreateSimplePipeGenerator(content, path);
                
                var generator = _generatorConcreteBuilder.GetGenerator();
                generator.Save();
                return Json("Archivo generado");
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
