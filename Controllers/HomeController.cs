using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdoptPetProject.Models;

using System.Drawing;
using Microsoft.AspNetCore.Localization;

namespace AdoptPetProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

   
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        
    }

    public IActionResult Index()
    {

        

        
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

        //Category category3 = context.Categories.FirstOrDefault(u => u.id == 1);
        //category3.catName = "Sürüngen";
        //context.SaveChanges();

        //Category cat1 = new()
        //{
        //    id = 4
        //};



        //context.Categories.RemoveRange(cat1);
        //context.SaveChanges();

        var filtre = context.Categories.Where(u => u.id >= 1 && u.id <= 2).ToList();
        var pets = context.Pets.ToList();
        var catList = context.Categories.ToList();
        var users = context.Users.ToList();
        ViewData["Pets"] = pets;
        ViewData["Categories"] = catList;
        ViewData["Users"] = users;



        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult About()
    {

        ViewData["Active"] = "About";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Active"] = "Contact";

        return View();
    }

    public IActionResult ChangeLanguage(string culture)
    {
        
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions() {Expires = DateTimeOffset.UtcNow.AddYears(1)});
        return Redirect(Request.Headers["Referer"].ToString());
        
    }
    
}

