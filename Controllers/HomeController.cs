using Microsoft.AspNetCore.Mvc;
using MithrasPieShop.Models;
using MithrasPieShop.ViewModels;

namespace MithrasPieShop.Controllers;


public class HomeController : Controller
{
    private readonly IPieRepository _pieRepository;

    public HomeController(IPieRepository pieRepository)
    {
        _pieRepository = pieRepository;
    }
    
    // GET
    public ViewResult Index()
    {
        var piesOfTheWeek = _pieRepository.PiesOfTheWeek;
        var homeViewModel = new HomeViewModel(piesOfTheWeek);
        return View(homeViewModel);
    }
}