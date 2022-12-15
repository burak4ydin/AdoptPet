using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdoptPetProject.Models;
using Microsoft.AspNetCore.Session;
using System.Drawing;

namespace AdoptPetProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IHttpContextAccessor session;
    public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        session = httpContextAccessor;
    }

    public IActionResult Index()
    {

        session.HttpContext.Session.SetString("Name","Burak");

        
        AdoptPetContext context = new AdoptPetContext();

        //Category category = new()
        //{
        //    catName= "Kedi"
        //};
        //Category category1 = new()
        //{
        //    catName = "Kuş"
        //};
        //Category category2 = new()
        //{
        //    catName = "Kemirgen"
        //};
        //context.Categories.AddRange(category,category1,category2);
        //context.SaveChanges();

        Category category3 = context.Categories.FirstOrDefault(u => u.id == 1);
        category3.catName = "Sürüngen";
        context.SaveChanges();

        //Category cat1 = new()
        //{
        //    id = 4
        //};



        //context.Categories.RemoveRange(cat1);
        //context.SaveChanges();

        var filtre = context.Categories.Where(u => u.id >= 1 && u.id <= 2).ToList();
        var categories = context.Categories.ToList();


        return View(filtre);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

