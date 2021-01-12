using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTraineeAssignment.Models;
using System.Net.Http;
using NLog;

namespace ProjectTraineeAssignment.Controllers
{
    public class AccountController : Controller
    {
        private static Logger logger = LogManager.GetLogger("myAppLoggerRule");


        /*
            This controller is called when user visits the registration page of our system. It returns the empty registration form to the user.
             */
        public ActionResult Register()
        {
            try
            {
                logger.Info("Entering Register action method (Get) of AccountController.");
                return View();
                
            }
            catch(Exception e)
            {
                logger.Error("Exception : " + e.Message);
                return RedirectToAction("Error");
            }
        }


        /*
           This controller is called when user fills the registration form and clicks on submit button. All the user data is stored in 
           registered_data variable. This method calls the PostRegister api in AccountApiController. After successful registration the user is
           redirected to login page.
             */
        [HttpPost]
        public ActionResult Register(RegisterModel registered_data)
        {
            try
            {
                logger.Info("Entering Register action method (Post) of AccountController.");
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("http://localhost:51720/api/");


                        //var serailized=JsonConvert.SerializeObject(productData);

                        //var content = new FormUrlEncodedContent(productData);
                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<RegisterModel>("AccountApi/PostRegister", registered_data);

                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            logger.Info("Exiting Register action method (Post) of AccountController. Registration Success.");
                            return RedirectToAction("Login");
                        }
                        else
                        {
                            logger.Error("Exiting Register action method (Post) of AccountController. Internal Server Error.");
                            return RedirectToAction("Error");
                        }
                    }
                }
                else
                {
                    logger.Info("Exiting Register action method (Post) of AccountController. Invalid Model State.");
                    return View();
                }
            }
            catch(Exception e)
            {
                logger.Error("Exception : " + e.Message);
                return RedirectToAction("Error");
            }
            
        }


        /*
            This controller is called when user visits the login page of our system. It returns the empty login form to the user.
             */
        public ActionResult Login()
        {
            try
            {
                logger.Info("Entering Login action method (Get) of AccountController.");
                return View();
            }
            catch(Exception e)
            {
                logger.Error("Exception : " + e.Message);
                return RedirectToAction("Error");
            }
        }


        /*
            This controller is called when user enters the email id and password and clicks on login button. The email id and password are then
            compared with the database. If credentials are correct then user is redirected to dashboard otherwise user is given a message.
             */
        [HttpPost]
        public ActionResult Login(LoginModel login_data)
        {
            try
            {
                logger.Info("Entering Login action method (Post) of AccountController.");
                if (ModelState.IsValid)
                {
                
                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("http://localhost:51720/api/");
                        var postTask = client.PostAsJsonAsync<LoginModel>("AccountApi/PostLogin", login_data);
                        postTask.Wait();
                        var result = postTask.Result;

                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsAsync<dynamic>();
                            var result_data = readTask.Result;
                           
                            Session["user_id"] = result_data.user_id.ToString();
                            Session["user_name"] = result_data.name.ToString();
                            logger.Info("Exiting Login action method (Post) of AccountController. Login Success.");
                            return RedirectToAction("Index","Home");
                        }
                        else if(result.StatusCode==System.Net.HttpStatusCode.NotFound)
                        {
                            ViewBag.IdPwdDontMatch = "Your email and password doesnt match";
                            logger.Info("Exiting Login action method (Post) of AccountController. Email & Password doesn't match.");
                            return View();
                        }
                        else
                        {
                            logger.Error("Exiting Login action method (Post) of AccountController. Internal Server Error.");
                            return RedirectToAction("Error");
                        }
                    }
                }
                else
                {
                    logger.Info("Exiting Login action method (Post) of AccountController. Invalid Model State.");
                    return View();
                }
                
            }
            catch (Exception e)
            {
                logger.Error("Exception : " + e.Message);
                return RedirectToAction("Error");
            }
            
        }


        /*
            This action method is called when user clicks on the logout button and it clears the session variable.
             */
        public ActionResult Logout()
        {
            try
            {
                logger.Info("Entering Logout action method of AccountController.");
                Session["user_id"] = null;
                return RedirectToAction("Login");
            }
            catch(Exception e)
            {
                logger.Error("Exception : " + e.Message);
                return RedirectToAction("Error");
            }
       }

        /*
            This action method is called when any exception occurs in the system and user is redirected to a view where he is given a message.
             */
        public ActionResult Error()
        {
            try
            {
                logger.Info("Entering Error action method of AccountController.");
                return View();
            }
            catch(Exception e)
            {
                logger.Error("Exception : " + e.Message);
                return RedirectToAction("Error");
            }
        }


    }
}