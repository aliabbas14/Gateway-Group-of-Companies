using AspNetCoreAssignment.Models;
using AspNetCoreAssignment.MVC.Filters;
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
    [ModifyHeaderResponse]
    public class EmployeeController : Controller
    {
        // GET: Employee
        [ResponseCache(Duration =3600,Location =ResponseCacheLocation.Any)]
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "")
            {
                return RedirectToAction("Login", "Account");
            }
            using (HttpClient client = new HttpClient())
            {
                var token = "Bearer " + HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Add("Authorization", token);
                using (var response =await client.GetAsync("https://localhost:44369/api/Employees/GetEmployees"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<EmployeesModel>>(apiResponse);
                    return View(result);
                }

            }
            

        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "") {
                return RedirectToAction("Login", "Account");
            }
            using (HttpClient client = new HttpClient()) {
                var token = "Bearer " + HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Add("Authorization", token);

                using (var response = await client.GetAsync("https://localhost:44369/api/Employees/GetEmployee?id="+id)) {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<EmployeesModel>(apiResponse);
                    return View(result);
                }

            }
        }

        // GET: Employee/Create
        public async Task<ActionResult> Create()
        {
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

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeesModel model)
        {
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

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
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

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeesModel model)
        {
            if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "") {
                return RedirectToAction("Login", "Account");
            }
            using (HttpClient client = new HttpClient()) {
                var token = "Bearer " + HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Add("Authorization", token);
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PutAsync("https://localhost:44369/api/Employees/PutEmployee?id="+model.Id, content)) {


                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
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

        
    }
}
