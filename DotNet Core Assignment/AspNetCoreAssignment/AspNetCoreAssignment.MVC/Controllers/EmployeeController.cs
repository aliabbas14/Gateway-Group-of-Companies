using AspNetCoreAssignment.Models;
using AspNetCoreAssignment.MVC.Filters;
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
    [ModifyHeaderResponse]
    public class EmployeeController : Controller
    {
        ILogger _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        //<summary>
        //    This method returns the list of employees.
        //</summary>
        [ResponseCache(Duration =3600,Location =ResponseCacheLocation.Any)]
        public async Task<ActionResult> Index()
        {
            try {
                if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "") {
                    return RedirectToAction("Login", "Account");
                }
                using (HttpClient client = new HttpClient()) {
                    var token = "Bearer " + HttpContext.Session.GetString("Token");
                    client.DefaultRequestHeaders.Add("Authorization", token);
                    using (var response = await client.GetAsync("https://localhost:44369/api/Employees/GetEmployees")) {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<EmployeesModel>>(apiResponse);
                        return View(result);
                    }

                }
            }
            catch(Exception e) {
                _logger.LogError(e.Message);
                return RedirectToAction("Error","Account");
            }

        }

        //<summary>
        //    This method returns all the details of particular employee based on the id. 
        //</summary>
        public async Task<ActionResult> Details(int id)
        {
            try {
                if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "") {
                    return RedirectToAction("Login", "Account");
                }
                using (HttpClient client = new HttpClient()) {
                    var token = "Bearer " + HttpContext.Session.GetString("Token");
                    client.DefaultRequestHeaders.Add("Authorization", token);

                    using (var response = await client.GetAsync("https://localhost:44369/api/Employees/GetEmployee?id=" + id)) {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<EmployeesModel>(apiResponse);
                        return View(result);
                    }

                }
            }
            catch(Exception e) {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    This method returns an empty form to create a new employee.
        //</summary>
        public async Task<ActionResult> Create()
        {
            try {
                if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "") {
                    return RedirectToAction("Login", "Account");
                }
                using (HttpClient client = new HttpClient()) {
                    var token = "Bearer " + HttpContext.Session.GetString("Token");
                    client.DefaultRequestHeaders.Add("Authorization", token);
                    using (var response = await client.GetAsync("https://localhost:44369/api/Employees/GetManagers")) {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<EmployeesModel>>(apiResponse);
                        ViewBag.Managers = result;
                        return View();
                    }

                }
            }
            catch(Exception e) {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }

           
        }

        //<summary>
        //    This method is called when user submits the employee form.
        //</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeesModel model)
        {
            try {
                if (ModelState.IsValid) {
                    if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "") {
                        return RedirectToAction("Login", "Account");
                    }
                    using (HttpClient client = new HttpClient()) {
                        var token = "Bearer " + HttpContext.Session.GetString("Token");
                        client.DefaultRequestHeaders.Add("Authorization", token);
                        StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://localhost:44369/api/Employees/PostEmployee", content)) {


                            return RedirectToAction("Index");
                        }
                    }
                }
                else {
                    return View();
                }
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    This method returns an edit form with all the predefined values.
        //</summary>
        public async Task<ActionResult> Edit(int id)
        {
            try {
                if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "") {
                    return RedirectToAction("Login", "Account");
                }
                using (HttpClient client = new HttpClient()) {

                    var token = "Bearer " + HttpContext.Session.GetString("Token");
                    client.DefaultRequestHeaders.Add("Authorization", token);

                    using (var response = await client.GetAsync("https://localhost:44369/api/Employees/GetManagers")) {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<EmployeesModel>>(apiResponse);
                        ViewBag.Managers = result;

                    }

                    using (var response = await client.GetAsync("https://localhost:44369/api/Employees/GetEmployee?id=" + id)) {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<EmployeesModel>(apiResponse);
                        return View(result);
                    }

                }
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    This method is called when user updates the employee details.
        //</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeesModel model)
        {
            try {
                if (ModelState.IsValid) {
                    if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "") {
                        return RedirectToAction("Login", "Account");
                    }
                    using (HttpClient client = new HttpClient()) {
                        var token = "Bearer " + HttpContext.Session.GetString("Token");
                        client.DefaultRequestHeaders.Add("Authorization", token);
                        StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                        using (var response = await client.PutAsync("https://localhost:44369/api/Employees/PutEmployee?id=" + model.Id, content)) {


                            return RedirectToAction("Index");
                        }
                    }
                }
                else {
                    return View();
                }
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    This method is called when an employee is deleted.
        //</summary>
        public async Task<ActionResult> Delete(int id)
        {
            try { 
            if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "") {
                return RedirectToAction("Login", "Account");
            }
            using (HttpClient client = new HttpClient()) {
                var token = "Bearer " + HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Add("Authorization", token);
                using (var response = await client.DeleteAsync("https://localhost:44369/api/Employees/DeleteEmployee?id=" + id)) {

                    return RedirectToAction("Index");
                }

            }
        }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        
    }
}
