using Microsoft.AspNetCore.Mvc;

namespace AdoptPetProject.Controllers;

public class AdoptController : Controller
{
    // GET
    public IActionResult Index()
    {
        ViewData["Active"] = "List";
        return View();
    }
}