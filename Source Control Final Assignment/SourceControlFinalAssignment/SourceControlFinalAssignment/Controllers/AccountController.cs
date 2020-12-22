using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SourceControlFinalAssignment.Models;
using System.IO;
using System.Web.Security;
using NLog;

namespace SourceControlFinalAssignment.Controllers
{
    /*
        This controller handles all the incoming requests related to Registratiom,login and signout. 
    */
    public class AccountController : Controller
    {

        private static Logger logger = LogManager.GetLogger("myAppLoggerRule");
        private static Logger loggerDB = LogManager.GetLogger("myAppLoggerRuleDB");

        /*
            This action method returns the registration form for getting data from user. 
        */
        public ActionResult Registration()
        {
            logger.Info("Entering Account Controller Registration method (GET)");
            loggerDB.Info("Entering Account Controller Registration method (GET)");
            return View();
        }


        /*
            When users submits the registration form this action method is called and it inserts the data into
            the database. 
        */
        [HttpPost]
        public ActionResult Registration(RegistrationModel registration)
        {
            try {
                logger.Info("Entering Account Controller Registration method (POST)");
                loggerDB.Info("Entering Account Controller Registration method (POST)");
                if (ModelState.IsValid)
                {
                    if (registration.photo != null && registration.photo.ContentLength > 0)
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"),
                                                   Path.GetFileName(registration.photo.FileName));
                        registration.photo.SaveAs(path);
                    }



                    using (var context = new SourceControlFinalAssignmentEntities())
                    {
                        Registration reg = new Registration()
                        {
                            FirstName = registration.FirstName,
                            LastName = registration.LastName,
                            Email = registration.Email,
                            Phone = registration.Phone,
                            Password = registration.Password,
                            Age = registration.Age,
                            Gender = registration.Gender,
                            Address = registration.Address,
                            photo = registration.photo.FileName

                        };

                        context.Registrations.Add(reg);
                        context.SaveChanges();
                        logger.Info("Exiting Account Controller Registration method (POST) after successfull registration");
                        loggerDB.Info("Exiting Account Controller Registration method (POST) after successfull registration");
                        return RedirectToAction("Login", "Account");
                    }
                }
                logger.Info("Exiting Account Controller Registration method (POST) after validation errors");
                loggerDB.Info("Exiting Account Controller Registration method (POST) after validation errors");
                return View();
            }
            catch(Exception e)
            {
                logger.Error("Exception " + e.Message);
                loggerDB.Error("Exception " + e.Message);
                return RedirectToAction("Error","Home");
            }
            
            
           }

        /*
            This action method reuturns the login form. 
        */
        public ActionResult Login()
        {
            logger.Info("Entering Account Controller Login method (GET)");
            loggerDB.Info("Entering Account Controller Login method (GET)");
            return View();
        }

        /*
            When the user submits the login form this actioni method is called and it verfies the email and 
            password and sets the session. 
        */
        [HttpPost]
        public ActionResult Login(LoginModel loginmodel)
        {
            try
            {
                logger.Info("Entering Account Controller Login method (POST)");
                loggerDB.Info("Entering Account Controller Login method (POST)");
                using (var context = new SourceControlFinalAssignmentEntities())
                {
                    int result = context.Registrations.Where(x => x.Email == loginmodel.Email && x.Password == loginmodel.Password).Select(x => x.RegistrationId).FirstOrDefault();
                    FormsAuthentication.SetAuthCookie(result.ToString(), false);
                    Session["user_id"] = result;
                    logger.Info("Exiting Account Controller Login method (POST) after successfull login");
                    return RedirectToAction("Index", "Home");
                }
                logger.Info("Exiting Account Controller Login method (POST) after login errors");
                loggerDB.Info("Exiting Account Controller Login method (POST) after login errors");
                return View();

            }
            catch(Exception e)
            {
                logger.Error("Exception " + e.Message);
                loggerDB.Error("Exception " + e.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        /*
            This action method is called when user clicks on signout button and it clears the cookies. 
        */
        public ActionResult Logout()
        {
            logger.Info("Entering Account Controller Logout method (GET)");
            loggerDB.Info("Entering Account Controller Logout method (GET)");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}