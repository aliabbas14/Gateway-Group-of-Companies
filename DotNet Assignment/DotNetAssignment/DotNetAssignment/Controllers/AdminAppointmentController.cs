using DotNetAssignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DotNetAssignment.Controllers
{
    public class AdminAppointmentController : Controller
    {
        // GET: AdminAppointment

        /*
         This method is called when admin wants to see all the appointments that are booked by the customers. It returns list of 
        booked appointments.
         */
        public new ActionResult View()
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51720/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("AdminAppointmentApi/Get");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<string>();
                        readTask.Wait();
                        ViewBag.category = JsonConvert.DeserializeObject(readTask.Result);
                        
                        return View();
                    }
                    else
                    {
                        
                        return RedirectToAction("Error", "Account");
                    }
                }

            }
            catch (Exception e)
            {
                
                return RedirectToAction("Error", "Account");
            }
        }

        /*
            This method is called when admin clicks on edit button of the list of appointments. It opens the form with the details
            filled.s
         */
        public ActionResult Edit(int id)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51720/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("ProductApi/Get/" + id);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<string>();
                        readTask.Wait();
                        AdminAppointment p = JsonConvert.DeserializeObject<AdminAppointment>(readTask.Result);
                       
                        return View(p);
                    }
                    else
                    { 
                        return RedirectToAction("Error", "Account");
                    }
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Account");
            }
        }

        /*
            This method is called when admin edits the appointment and clicks on the submit button. It collects the data and edits
            the data in the database.
         */
        [HttpPost]
        public ActionResult Edit(AdminAppointment model)
        {
            try
            {         
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51720/api/");

                    //HTTP POST
                    var putTask = client.PutAsJsonAsync("AdminAppointmentApi/Edit", model);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        
                        Session["ServiceEdited"] = "1";
                        return RedirectToAction("Display");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Account");
                    }
                }

            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Account");
            }
        }


        /*
            This method is called when the admin rejects the appointment for what so ever reason. It changes the value of 
            status field.
         */
        public ActionResult Disapprove(int id)
        {
            try
            {
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51720/api/");

                    //HTTP DELETE
                    var deleteTask = client.DeleteAsync("AdminAppointmentApi/GetDisapprove/" + id);
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        
                        Session["ServiceDeleted"] = "1";
                        return RedirectToAction("Display");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Account");
                    }

                }
            }
            catch (Exception e)
            {
                
                return RedirectToAction("Error", "Account");
            }
        }
    }
}