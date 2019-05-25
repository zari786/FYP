﻿using CodeFirst.DLA;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CodeFirst.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
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
                    if (dBContext.userAccounts.Where(m => m.Email == account.Email) == null)
                    {
                        dBContext.userAccounts.Add(account);
                        dBContext.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = "Registered Successfully";
                    }

                    else
                    {
                        ModelState.AddModelError("Error", "Email Already Exists");
                    }
                }
                
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            if (ModelState.IsValid)
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
                        Session["Name"] = user.Name;
                        Session["Email"] = user.Email.ToString();
                        return RedirectToAction("Index", "Home");
                    }
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