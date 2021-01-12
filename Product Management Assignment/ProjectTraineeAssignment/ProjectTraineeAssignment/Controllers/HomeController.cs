using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTraineeAssignment.Controllers
{
    public class HomeController : Controller
    {
        private static Logger logger = LogManager.GetLogger("myAppLoggerRule");

        /*
            This action method checks if the user is authentciated and if user is authentcated it return the dashboard view otherwise redirects
            to the login page.
             */
        public ActionResult Index()
        {
            try
            {
                logger.Info("Entering Index action method of HomeController.");
                if ((string)Session["user_id"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                ViewBag.username = Session["user_name"];
                logger.Info("Exiting Index action method of HomeController.");
                return View();
            }
            catch(Exception e)
            {
                logger.Error("Exception : " + e.Message);
                return RedirectToAction("Error","Account");
            }
        }
    }
}