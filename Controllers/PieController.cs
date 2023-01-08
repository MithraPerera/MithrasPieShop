using Microsoft.AspNetCore.Mvc;
using MithrasPieShop.Models;
using MithrasPieShop.ViewModels;

namespace MithrasPieShop.Controllers;

public class PieController : Controller
{
    // Constructor Dependency Injection from the registered services in Program.cs
    private readonly IPieRepository _pieRepository;

    private readonly ICategoryRepository _categoryRepository;

    public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
    {
        _pieRepository = pieRepository;
        _categoryRepository = categoryRepository;
    }

    // GET
    public IActionResult List()
    {
        //ViewBag.CurrentCategory = "Cheese cakes"; //Viewbag passes values dynamically - you can add any value you want and its passed to the view
        
        // Strongly Typed Views //
        //means that we can pass a model to our view and the view can basically dig into these properties and that will also render dynamically‑generated HTML
        //return View(_pieRepository.AllPies);
        
        // Using a ViewModel class to pass all the data needed for the view in 1 shot //
        PieListViewModel piesListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese Cakes");
        return View(piesListViewModel);
    }
}