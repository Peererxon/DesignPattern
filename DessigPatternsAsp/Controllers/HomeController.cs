using System.Diagnostics;
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

    public HomeController(IOptions<MyConfig> config)
    { 
        _config = config;
    }

    public IActionResult Index()
    {
        Log.GetInstance(_config.Value.PathLog).Save($"Usuario entro en Index a las {actualDate}");
        return View();
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

