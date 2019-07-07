using CodeFirst.DLA;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CodeFirst.Controllers
{
    //[AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            List<string> CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(R.EnglishName)))
                {
                    CountryList.Add(R.EnglishName);
                }
            }

            CountryList.Sort();
            ViewBag.Message = CountryList;
            return View();
        }

        
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {

            if (ModelState.IsValid)
            {
                using(DBContext dBContext = new DBContext())
                {
                    //if (dBContext.userAccounts.Where(m => m.Email == account.Email) == null)
                    //{
                        dBContext.userAccounts.Add(account);
                        dBContext.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = "Registered Successfully";
                    return View();
                    //}

                    //else
                    //{
                        
                    //}
                }
                
            }
            ModelState.AddModelError("Error", "Email Already Exists");
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (DBContext dB = new DBContext())
                {
                    if(dB.userAccounts.Where(m => m.Email == user.Email && m.Password == user.Password).FirstOrDefault() == null)
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("Error", "Incorrect Email or Password");
                    }
                    else
                    {
                        Response.Write("<script>alert('You are logged in as" + user.Name + "') </script>");
                        Session["Name"] = user.Name;
                        Session["Email"] = user.Email.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}