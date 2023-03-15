using System.Diagnostics;
using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DessigPatternsAsp.Configuration;
using DessigPatternsAsp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tools;
namespace DessigPatternsAsp.Controllers;

public class HomeController : Controller
{

    private readonly IOptions<MyConfig> _config;
    private readonly DateTime actualDate = DateTime.Today;
    private readonly IRepository<Beer> _repository;

    public HomeController(IOptions<MyConfig> config, IRepository<Beer> repository)
    { 
        _config = config;
        _repository = repository;
    }

    public IActionResult Index()
    {
        Log.GetInstance(_config.Value.PathLog).Save($"Usuario entro en Index a las {actualDate}");
        IEnumerable<Beer> model = _repository.Get();
        // esto se lo pasa como modelo a la vista
        return View("Index", model);
    }

    public IActionResult Privacy()
    {
        Log.GetInstance(_config.Value.PathLog).Save($"Usuario entro en Privacy a las {actualDate}");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

