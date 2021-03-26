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
    public class EmployeeController : Controller
    {
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
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
            using (HttpClient client = new HttpClient()) {
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
            using (HttpClient client = new HttpClient()) {
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
            using (HttpClient client = new HttpClient()) {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:44369/api/Employees/PostEmployee", content)) {


                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (HttpClient client = new HttpClient()) {

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
            using (HttpClient client = new HttpClient()) {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await client.PutAsync("https://localhost:44369/api/Employees/PutEmployee?id="+model.Id, content)) {


                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient()) {
                using (var response = await client.DeleteAsync("https://localhost:44369/api/Employees/DeleteEmployee?id=" + id)) {
                    
                    return RedirectToAction("Index");
                }

            }
        }

        
    }
}
