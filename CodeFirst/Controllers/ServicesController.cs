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
        DBContext dBContext = new DBContext();
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
            string message = "";
            string error = null;
            if (ModelState.IsValid)
            {
                dBContext.services.Add(services);
                dBContext.SaveChanges();
                ModelState.Clear();
                message = "Your Request has been Submited Our Team Will Contact you in a while";
            }
            else
            {
                error = "Your Request  Could not be Submited Please Try Again!";
            }
            ViewBag.Message = message;
            ViewBag.Error = error;
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
            string message = "";
            string error = null;
            if (ModelState.IsValid)
            {
                dBContext.services.Add(services);
                dBContext.SaveChanges();
                ModelState.Clear();
                message = "Your Request has been Submited Our Team Will Contact you in a while";
            }
            else
            {
                error = "Your Request  Could not be Submited Please Try Again!";
            }
            ViewBag.Message = message;
            ViewBag.Error = error;
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
            string message = "";
            string error = null;
            if (ModelState.IsValid)
            {
                dBContext.services.Add(services);
                dBContext.SaveChanges();
                ModelState.Clear();
                message = "Your Request has been Submited Our Team Will Contact you in a while";
            }
            else
            {
                error = "Your Request  Could not be Submited Please Try Again!";
            }
            ViewBag.Message = message;
            ViewBag.Error = error;
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
            string message = "";
            string error = null;
            if (ModelState.IsValid)
            {
                dBContext.services.Add(services);
                dBContext.SaveChanges();
                ModelState.Clear();
                message = "Your Request has been Submited Our Team Will Contact you in a while";
            }
            else
            {
                error = "Your Request  Could not be Submited Please Try Again!";
            }
            ViewBag.Message = message;
            ViewBag.Error = error;
            return View();
        }
    }
}