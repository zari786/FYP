using CodeFirst.DLA;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GroundHandling()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GroundHandling(Services services)
        {
            if (ModelState.IsValid)
            {
                using (DBContext dBContext = new DBContext())
                {
                        dBContext.services.Add(services);
                        dBContext.SaveChanges();
                        ModelState.Clear();
                    return RedirectToAction("Home/Index");
                }
            }
            ModelState.AddModelError("Error", "Eroor Occur");
            return View();
        }

    }
}