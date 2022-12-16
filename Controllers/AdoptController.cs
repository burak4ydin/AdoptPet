using AdoptPetProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPetProject.Controllers;

public class AdoptController : Controller
{




    // GET
    public IActionResult Index()
    {
        ViewData["Active"] = "List";
        AdoptPetContext context = new AdoptPetContext();



        var pets = context.Pets.ToList();
        var catList = context.Categories.ToList();
        var users = context.Users.ToList();
        ViewData["Pets"] = pets;
        ViewData["Categories"] = catList;
        ViewData["Users"] = users;
        return View();
    }

    [HttpPost]
    public IActionResult Index(string keyword,int catId)
    {
        
        ViewData["Active"] = "List";

        AdoptPetContext context = new AdoptPetContext();

         
        // var terms = keyword.Trim();
        

        if (keyword != null && catId==0)
        {
            // Response.WriteAsync("<script>alert('rrData inserted successfully "+keyword+" "+catId+"')</script>");
            var pets = context.Pets.Where(q=> q.name.Contains(keyword))
                .ToList();
            var catList = context.Categories.ToList();
            var users = context.Users.ToList();
            ViewData["Pets"] = pets;
            ViewData["Categories"] = catList;
            ViewData["Users"] = users;
        }
        else if (keyword == null && catId != 0)
        {          
            // Response.WriteAsync("<script>alert('aaData inserted successfully keyword:"+keyword+" catOd:"+catId+"')</script>");

            var pets = context.Pets.Where(q => q.catId == catId).ToList();
            var catList = context.Categories.ToList();
            var users = context.Users.ToList();
            ViewData["Pets"] = pets;
            ViewData["Categories"] = catList;
            ViewData["Users"] = users;
        }
        else if (keyword != null && catId != 0)
        {           
            // Response.WriteAsync("<script>alert('ccData inserted successfully keyword:"+keyword+" catOd:"+catId+"')</script>");

            var pets = context.Pets.Where(q  => q.name.Contains(keyword) && q.catId == catId )
                .ToList();
            var catList = context.Categories.ToList();
            var users = context.Users.ToList();
            ViewData["Pets"] = pets;
            ViewData["Categories"] = catList;
            ViewData["Users"] = users;
        }
        else if (keyword == null && catId == 0)
        {            
            // Response.WriteAsync("<script>alert('ssData inserted successfully "+keyword+" "+catId+"')</script>");

            var pets = context.Pets.ToList();
            var catList = context.Categories.ToList();
            var users = context.Users.ToList();
            ViewData["Pets"] = pets;
            ViewData["Categories"] = catList;
            ViewData["Users"] = users;
        }
        
        return View();
    }
    
    
    public IActionResult Info(string id)
    {
        AdoptPetContext context = new AdoptPetContext();
        // Response.WriteAsync("<script>alert('Data inserted successfully "+id+"')</script>");
        ViewData["selectedPet"] = Int32.Parse(id);
        var pets = context.Pets.ToList();
        var catList = context.Categories.ToList();
        var users = context.Users.ToList();
        ViewData["Pets"] = pets;
        ViewData["Categories"] = catList;
        ViewData["Users"] = users;
        return View();
    }
}