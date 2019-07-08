﻿using CodeFirst.DLA;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CodeFirst.Controllers
{
    //[AllowAnonymous]
    public class AccountController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Account
        public ActionResult Index()
        {
            
            return View();
        }

        
        public ActionResult Register()
        {
            //List<string> CountryList = new List<string>();
            //CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            //foreach (CultureInfo CInfo in CInfoList)
            //{
            //    RegionInfo R = new RegionInfo(CInfo.LCID);
            //    if (!(CountryList.Contains(R.EnglishName)))
            //    {
            //        CountryList.Add(R.EnglishName);
            //    }
            //}

            //CountryList.Sort();
            //ViewBag.CountryList = CountryList;
            return View();
        }
        
        [HttpPost]
        public ActionResult Register([Bind(Exclude ="IsEmailVerified,ActivationCode")] Customer account)
        {
            SelectList list = new SelectList("CountryList");
            account.Country = list.ToString();

            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                account.ActivationCode = Guid.NewGuid();
                account.isEmailVerified = false;

                var isExist = isEmailExist(account.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExit", "Email Already Exist");
                    return View(account);
                }
                account.Password = Crypto.Hash(account.Password);
                account.ConfirmPassword = Crypto.Hash(account.ConfirmPassword);
                db.userAccounts.Add(account);
                db.SaveChanges();
                SendVerificationLinkEmail(account.Email, account.ActivationCode.ToString());
                message = "Registration Successfully done. Account Activation link" +
                           "has been sent to your email id:" + account.Email;
                Status = true;
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(account);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login, string ReturnUrl)
        {
            string message = "";
            ViewBag.Message = message;

            var result = db.userAccounts.Where(m => m.Email == login.Email).FirstOrDefault();
            if (result != null)
            {
                if (string.Compare(Crypto.Hash(login.Password), result.Password) == 0)
                {
                    int timeout = login.RememberMe ? 525600 : 20;        //525600 minute = 1 year...
                    var ticket = new FormsAuthenticationTicket(login.Email,login.RememberMe,timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    Session["Email"] = login.Email;
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    message = "Invalid Credentials Provided";
                }
            }
            else
            {
                message = "Invalid Credentials Provided";
            }
            ViewBag.Message = message;
            return View();
        }

        
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string EmailID)
        {
            string message = "";
            bool Status = false;

            var result = db.userAccounts.Where(a => a.Email == EmailID).FirstOrDefault();
            if(result != null)
            {
                string restCode = Guid.NewGuid().ToString();
                SendVerificationLinkEmail(result.Email, restCode, "ResetPassword");
                result.ResetPassword = restCode;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                message = "Reset Password Link has been sent to your email Id";
            }
            else
            {
                message = "Account not Found";
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult ResetPassword(string Id)
        {
            var result = db.userAccounts.Where(a => a.ResetPassword == Id).FirstOrDefault();
            if (result != null)
            {
                ResetPasswordModel resetPasswordModel = new ResetPasswordModel();
                resetPasswordModel.ResetCode = Id;
                return View(resetPasswordModel);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";

            //if (ModelState.IsValid)
            //{
                var result = db.userAccounts.Where(a => a.ResetPassword == model.ResetCode).FirstOrDefault();
                if (result != null)
                {
                    result.Password = Crypto.Hash(model.NewPassword);
                    result.ResetPassword = "";
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    message = "New Password Updated Successfylly";
                }
            else
            {
                message = "Error Occured";
            }
            //}

            ViewBag.Message = message;
            return View(model);
        }

        [NonAction]
        public bool isEmailExist(string email)
        {
            var result = db.userAccounts.Where(a => a.Email == email).FirstOrDefault();
            return result != null;
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailId, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Account/"+emailFor+"/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("zaryababbasi786@gmail.com", "AL-Naseeb Aviation");
            var toEmail = new MailAddress(emailId);
            var fromEmailPassword = "Abbasi333";
            string body = "";
            string subject = "";
            if(emailFor == "VerifyAccount")
            {
                subject = "Your Account is Successfully Created!";
                body = "<br /><br /> We are excited to tell you that your AL-Nasseb Aviation Account is Created." +
                    "Please click on the link given below to access your account" +
                    "<br /><br /><a href='" + link + "'>" + link + "</a>";
            }
            else if(emailFor == "ResetPassword")
            {
                subject = "Reset Password!";

                body = "<br /><br />Hi! We got request for reset your account password." +
                    "Please click on the link given below to reset your password" +
                    "<br /><br /><a href=" + link + ">Reset Password Link</a>";
            }
            
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                
            })
            smtp.Send(message);

        }

        [HttpGet]
        public ActionResult VerifyAccount(string Id)
        {
            bool Status = false;
            db.Configuration.ValidateOnSaveEnabled = false;
            var result = db.userAccounts.Where(a => a.ActivationCode == new Guid(Id)).FirstOrDefault();
            if(result != null)
            {
                result.isEmailVerified = true;
                db.SaveChanges();
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request";
            }
            ViewBag.Status = true;
            return View();
        }
    }
}