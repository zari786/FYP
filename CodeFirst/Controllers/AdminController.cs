using CodeFirst.DLA;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Pending()
        {
            DBContext db = new DBContext();
            return View(db.services.ToList());
        }

        //public ActionResult PendingPost()
        //{
        //    return View(GetAllPendingPost());
        //}

        //IEnumerable<Services> GetAllPendingPost() {
        //    using (DBContext db = new DBContext())
        //    {
        //        IEnumerable<Services> services = new List<Services>();
        //        services = db.services.Where(s => s.isCompleted == false);
        //    }
        //    return View(services);
        //}

        //public ActionResult CompletedPost()
        //{
        //    return View(GetAllCompletedPost());
        //}

        //IEnumerable<Services> GetAllCompletedPost()
        //{
        //    using (DBContext db = new DBContext())
        //    {
        //        IEnumerable<Services> services = new List<Services>();
        //        services = db.services.Where(s => s.isCompleted == true);
        //    }
        //    return View(services);
        //}
    }
}
