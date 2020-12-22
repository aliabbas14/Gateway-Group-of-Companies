using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceControlFinalAssignment.Controllers
{
    public class HomeController : Controller
    {

        private static Logger logger = LogManager.GetLogger("myAppLoggerRule");
        private static Logger loggerDB = LogManager.GetLogger("myAppLoggerRuleDB");
        /*
            This action method can only be accessed by authrnticated users and returns a view with welcome
            message.
             */
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                logger.Info("Entering Home Controller Index method (GET)");
                loggerDB.Info("Entering Home Controller Index method (GET)");
                using (var context = new SourceControlFinalAssignmentEntities())
                {
                    var user_id = (int)Session["user_id"];
                    var result = context.Registrations.Where(x => x.RegistrationId == user_id).FirstOrDefault();
                    ViewBag.photo = "/Images/" + result.photo;
                    ViewBag.name = result.FirstName + " " + result.LastName;

                }
                logger.Info("Exiting Home Controller Index method (GET)");
                loggerDB.Info("Exiting Home Controller Index method (GET)");
                return View();
            }
            catch(Exception e)
            {
                logger.Error("Exception " + e.Message);
                loggerDB.Error("Exception " + e.Message);
                return RedirectToAction("Error", "Home");
            }
        }


        public ActionResult Error()
        {
            logger.Info("Entering Home Controller Error method (GET)");
            loggerDB.Info("Entering Home Controller Error method (GET)");
            return View();
        }
    }
}