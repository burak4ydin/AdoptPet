using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptPetProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdoptPetProject.Controllers
{
    public class LoginController : Controller
    {
        private const bool V = true;

       


        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewData["username"] = "boş";
            ViewData["password"] = "boş";
            ViewData["registerOK"] = "boş";

            return View();
        }


        //POST Register
        [HttpPost]
        public IActionResult Index(string username, string password)
        {

            ViewData["username"] = username;
            ViewData["password"] = password;


        AdoptPetContext context = new AdoptPetContext();


            User exists = context.Users.FirstOrDefault(u => u.username == username);

            if (exists != null)
            {
                ViewData["registerOK"] = "error";
                ViewData["hata"] = "Kullanıcı Adı Kayıtlı";
            }
            else
            {
                ViewData["registerOK"] = "ok";

            }



            return View();
        }
    }
}

