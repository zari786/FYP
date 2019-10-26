using CodeFirst.DLA;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    
    public class AdminController : Controller
    {
        DBContext db = new DBContext();

        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult Pending()
        {
            if (Session["Email"] != null)
            {
                var result = db.services.Where(a => a.IsCompleted == false).ToList();
                return View(result);
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        [HttpGet]
        public ActionResult UpdateStatus()
        {
            if (Session["Email"] != null)
            {
                var result = db.services.Where(a => a.IsCompleted == false).ToList();
                return View(result);
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

        [HttpGet]
        public ActionResult UpdateStatusBool(int id)
        {
            var result = db.services.Where(a => a.ServicesId == id).FirstOrDefault();
            if (result != null)
            {
                result.IsCompleted = true;
                db.SaveChanges();
            }
            return RedirectToAction("UpdateStatus");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicesId,FlightNo,RegistrationNo,Country,ArrivalRoute,ArrivalDestination,Address,GroundHandling,MTOW,PassengerHandling,ATCFlightPlan,LoadingOffLoading,Catering,NoOfPassenger,NoOfMeal,MealInformation,Refueling,TypeOfFuel,Quantity,OverFlyPermit,Itenary,EntryPoint,ExitPoint,Comment")] Services services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(services).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(services);
        }

        [HttpGet]
        public ActionResult CompletedPost()
        {
            if (Session["Email"] != null)
            {
                var result = db.services.Where(a => a.IsCompleted == true).ToList();
                return View(result);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }       
        }

        [HttpGet]
        public ActionResult ViewCustomer()
        {
            if (Session["Email"] != null)
            {
                return View(db.userAccounts.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult BlockCustomer()
        {
            if (Session["Email"] != null)
            {
                return View(db.userAccounts.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult AddScheduleFlight()
        {
            if (Session["Email"] != null)
            {
                var result = db.userAccounts.Where(a => a.IsSchedule == false).ToList();
                return View(result);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult AddScheduledFlightBool(int id)
        {
            var result = db.userAccounts.Where(a => a.CustomerId == id).FirstOrDefault();
            if (result != null)
            {
                result.IsSchedule = true;
                db.SaveChanges();
            }
            return RedirectToAction("AddScheduleFlight");
        }
        [HttpGet]
        public ActionResult ScheduleFlights()
        {
            var result = db.userAccounts.Where(a => a.IsSchedule == true).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult DeleteScheduleFlights()
        {
            if (Session["Email"] != null)
            {
                var result = db.userAccounts.Where(a => a.IsSchedule == true).ToList();
                return View(result);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult DeleteScheduleFlightsBool(int id)
        {
            var result = db.userAccounts.Where(a => a.CustomerId == id).FirstOrDefault();
            if (result != null)
            {
                result.IsSchedule = false;
                db.SaveChanges();
            }
            return RedirectToAction("DeleteScheduleflights");
        }
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.userAccounts.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.userAccounts.Find(id);
            db.userAccounts.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("BlockCustomer");
        }
    }
}
