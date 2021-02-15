using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DotNetAssignment.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        /*
         This method is called when the user request for the registration page. It returns the registration form.
         */
        public ActionResult Register()
        {
            return View();
        }


        /*
            This method is called when user fills the registration form and submits the form. It collects the user's form data and
            calls the api.
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {

            try
            {
               
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("http://localhost:51720/api/");


                        //var serailized=JsonConvert.SerializeObject(productData);

                        //var content = new FormUrlEncodedContent(productData);
                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<Register>("AccountApi/PostRegister", model);

                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            
                            return RedirectToAction("Login");
                        }
                        else
                        { 
                            return RedirectToAction("Error");
                        }
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Error");
            }
            
        }

        /*
         This method is called when user requests for the login form. It returns empty login form.
         */
        public ActionResult Login()
        {
            return View();
        }


        /*
            This method is called when user submits the login form after entering email and password. It collects the user data
            and calls the api.
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            try
            {
                
                if (ModelState.IsValid)
                {

                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("http://localhost:51720/api/");
                        var postTask = client.PostAsJsonAsync<Login>("AccountApi/PostLogin", model);
                        postTask.Wait();
                        var result = postTask.Result;

                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsAsync<dynamic>();
                            var result_data = readTask.Result;

                            Session["user_id"] = result_data.user_id.ToString();
                            Session["user_name"] = result_data.name.ToString();
                            
                            return RedirectToAction("Index", "Home");
                        }
                        else if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            ViewBag.IdPwdDontMatch = "Your email and password doesnt match";
                            
                            return View();
                        }
                        else
                        {
                            
                            return RedirectToAction("Error");
                        }
                    }
                }
                else
                {
                    
                    return View();
                }

            }
            catch (Exception e)
            {
                
                return RedirectToAction("Error");
            }
            
        }
    }
}