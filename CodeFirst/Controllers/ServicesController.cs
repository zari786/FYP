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
        
        public ActionResult GetGroundHandling()
        {
            if (Session["Email"] != null)
            {
                return View();
            }
            else
            {
                ViewBag.Message = "Please Login to Access the Services";
                
            }
            return View("GroundHandling");
        }

        [HttpPost]
        public ActionResult GetGroundHandling(Services services)
        {
            if (ModelState.IsValid)
            {
                using (DBContext dBContext = new DBContext())
                {
                        dBContext.services.Add(services);
                        dBContext.SaveChanges();
                        ModelState.Clear();
                    return RedirectToAction("Index" , "Home");
                }
            }
            ModelState.AddModelError("Error", "Eroor Occur");
            return View();
        }

        public ActionResult Refueling()
        {
            return View();
        }

        public ActionResult GetRefueling()
        {
            if (Session["Email"] != null)
            {
                return View();
            }
            else
            {
                ViewBag.Message = "Please Login to Access the Services";

            }
            return View("Refueling");
        }

        [HttpPost]
        public ActionResult GetRefueling(Services services)
        {
            if (ModelState.IsValid)
            {
                using (DBContext dBContext = new DBContext())
                {
                    dBContext.services.Add(services);
                    dBContext.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("Error", "Eroor Occur");
            return View();
        }

        
        public ActionResult Cattering()
        {
            return View();
        }

        public ActionResult GetCattering()
        {
            if (Session["Email"] != null)
            {
                return View();
            }
            else
            {
                ViewBag.Message = "Please Login to Access the Services";

            }
            return View("Cattering");
        }

        [HttpPost]
        public ActionResult GetCattering(Services services)
        {
            if (ModelState.IsValid)
            {
                using (DBContext dBContext = new DBContext())
                {
                    dBContext.services.Add(services);
                    dBContext.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("Error", "Eroor Occur");
            return View();
        }

        public ActionResult OverFlyPermit()
        {
            return View();
        }

        public ActionResult GetOverFlyPermit()
        {
            if (Session["Email"] != null)
            {
                return View();
            }
            else
            {
                ViewBag.Message = "Please Login to Access the Services";

            }
            return View("OverFlyPermit");
        }

        [HttpPost]
        public ActionResult GetOverFlyPermit(Services services)
        {
            if (ModelState.IsValid)
            {
                using (DBContext dBContext = new DBContext())
                {
                    dBContext.services.Add(services);
                    dBContext.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("Error", "Eroor Occur");
            return View();
        }
    }
}