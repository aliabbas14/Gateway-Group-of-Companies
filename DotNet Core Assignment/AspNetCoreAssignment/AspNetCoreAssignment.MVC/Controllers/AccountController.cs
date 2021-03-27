using AspNetCoreAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreAssignment.MVC.Controllers
{
    public class AccountController : Controller
    {
        ILogger _logger;
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        
        //<summary>
        //    This method returns an empty login page.
        //</summary>
        public ActionResult Login()
        {
            try {
                return View();
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    This method is called when user submits the login form.
        //</summary>
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try {
                using (HttpClient client = new HttpClient()) {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    using (var response = await client.PostAsync("https://localhost:44369/api/Account/Login", content)) {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            HttpContext.Session.SetString("Token", apiResponse);
                            HttpContext.Session.SetString("Username", model.Username);
                            return RedirectToAction("Index", "Home");
                        }
                        else {
                            ViewBag.Message = "Username or Password is incorrect.";
                            return View();
                        }



                    }
                }
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    This method is called when user wants to logout.
        //</summary>
        [HttpGet]
        public  IActionResult Logout()
        {
            try {
                HttpContext.Session.SetString("Token", "");
                HttpContext.Session.SetString("Username", "");

                return RedirectToAction("Login", "Account");
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    This method is called whenever any error occurs in th site.
        //</summary>
        public IActionResult Error()
        {
            return View();
        }
    }
}
