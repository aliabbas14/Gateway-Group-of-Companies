using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SourceControlAssignment1.Models;
using SourceControlAssignment1.Db;

namespace SourceControlAssignment1.Controllers
{
    /*This is the home controller.
     This controller has the action method named "Index" which will return registration form view.
     It also has action method that will be called when the form is submitted.*/
    public class HomeController : Controller
    {
        /*This is reference variable of class DBOperations from SourceControlAssignment1.Db (Class Library) which contains
          methods that inserts form data into database*/
        DBOperations db;

        /*This is constructor of Home Controller*/
        public HomeController()
        {
            /*Initalizing the reference variable db*/
            db = new DBOperations();
        }
        

        /*This action method returns the view which contains the registration form.*/
        public ActionResult Index()
        {
            return View();
        }


        /*This action method is called when the form is submitted from Index View and all the data comes in
          RegistrationFormModel object which is in SourceControlAssignment1.Models (Class Library)
          This action method also calls addNewRegistrationForm() which is declared in DBOperations class, this method
          inserts the form data in the database.
          And after successful insertion of data it clears the model state and sends message to the view.
             */
        [HttpPost]
        public ActionResult Index(RegistrationFormModel r)
        {
            if(ModelState.IsValid)
            {
                db.addNewRegistrationForm(r);
                ModelState.Clear();
                ViewBag.success_msg = "Data added in the DataBase";
            }
            return View();
        }
    }
}