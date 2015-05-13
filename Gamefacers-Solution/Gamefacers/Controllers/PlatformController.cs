using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gamefacers.Models;
using Gamefacers.Repositories;

namespace Gamefacers.Controllers
{
    public class PlatformController : Controller
    {
        IPlatformRepo platformRepo = new PlatformRepo();


        // GET: Platform
        public ActionResult Index()
        { 
            return View(platformRepo.GetAllPlatforms());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var NewPlatformName = collection["Name"];
            var NewPlatformUrl = collection["PhotoUrl"];
            Platform newPlatform = new Platform{Name = NewPlatformName, PhotoUrl = NewPlatformUrl};
            platformRepo.CreatePlatform(newPlatform);

            return Redirect("Index");
        }


    }
}