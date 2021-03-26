using AspNetCoreAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        // GET: AccountController

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            using (HttpClient client = new HttpClient()) {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:44369/api/Account/Login", content)) {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                   // HttpContext.Session.SetString("Token", apiResponse);
                    HttpContext.Session.SetString("Username", model.Username);

                    return View();
                }
            }
        }


    }
}
