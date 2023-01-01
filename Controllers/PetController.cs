using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AdoptPetProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdoptPetProject.Controllers
{
    public class PetController : Controller
    {

        private readonly IHttpContextAccessor session;

        AdoptPetContext context = new AdoptPetContext();


        public PetController(IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor;

        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewData["Active"] = "Pet";
            var categories = context.Categories.ToList();

            return View(categories);
        }

        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(string name,int age,string location,int catId,string description, IFormFile image)
        {

            //byte[] imageArray = System.IO.File.ReadAllBytes(image);
            //string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            //string fileName = Path.GetFileName(image.FileName);
            //ViewData["base64"] = fileName;
            string s = "";
            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                var fileBytes = ms.ToArray();
                s = Convert.ToBase64String(fileBytes);


                var pet = new Pet()
                {
                    name = name,
                    province = location,
                    catId = catId,
                    description=description,
                    photoLink= "data:image/jpeg;base64, " + s,
                    age=age,
                    userId = Int32.Parse(session.HttpContext.Session.GetString("userID"))
                };

                context.Pets.Add(pet);
                context.SaveChanges();
                ViewData["added"] = "ok";
                session.HttpContext.Session.SetString("token", "n1kl2ml21njk1n2jk1");

                // act on the Base64 data
            }
            var categories = context.Categories.ToList();


            return View(categories);
        }

    }

}

