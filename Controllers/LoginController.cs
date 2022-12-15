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

        private readonly IHttpContextAccessor session;

        AdoptPetContext context = new AdoptPetContext();
        
            public LoginController(IHttpContextAccessor httpContextAccessor)
            {
                session = httpContextAccessor;

            }
        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewData["username"] = "boş";
            ViewData["password"] = "boş";
            ViewData["registerOK"] = "boş";


            //if (TempData["loginOK"] == "ok")
            //{
            //    ViewData["loginOK"] = "ok";
            //}
            //else if(TempData["loginOK"] == "error")
            //{
            //    ViewData["loginOK"] = "error";
            //    ViewData["loginError"] = "Hata";

            //}

            return View();
        }


        //POST Register
        [HttpPost]
        public IActionResult Index(string username, string password,string again)
        {

            ViewData["username"] = username;
            ViewData["password"] = MD5Hash.Hash.Content(password);

            if(again != null)
            {

            User exists = context.Users.FirstOrDefault(u => u.username == username);

            if (exists != null)
            {
                ViewData["registerOK"] = "error";
                ViewData["hata"] = "Kullanıcı Adı Kayıtlı";
            }
            else
            {
                ViewData["registerOK"] = "ok";

                User user = new User
                {
                    username = username,
                    password = MD5Hash.Hash.Content(password)
                };

                context.Users.Add(user);
                context.SaveChanges();

            }

            }
            else
            {
                User exists = context.Users.FirstOrDefault(u => u.username == username);

                if (exists != null)
                {
                    if (exists.password == MD5Hash.Hash.Content(password))
                    {
                        ViewData["loginOK"] = "ok";
                        session.HttpContext.Session.SetString("token", "kn12m3121d1mlk1m2");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewData["loginOK"] = "error";

                        ViewData["loginError"] = "Parola Hatalı";
                    }
                }
                else
                {
                    ViewData["loginOK"] = "error";
                    ViewData["loginError"] = "Kullanıcı Bulunamadı";
                }
            }




            return View();
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {


            

            return RedirectToAction("Index");

            
        }

        public IActionResult Logout(string val)
        {
            session.HttpContext.Session.Remove("token");
            return RedirectToAction("Index", "Home");
        }


    }
}

