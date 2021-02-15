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
    public class AppointmentController : Controller
    {
        // GET: Appointment

        /*
            This method is called when user wants to book an appointment. It opens empty booking form.
         */
        public ActionResult Booking()
        {
            return View();
        }


        /*
            This method is called when user books an appointment. It collects the data of the form and calls the api
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(BookAppointment model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:51720/api/");

                        var postTask = client.PostAsJsonAsync<BookAppointment>("ProductApi/Post", model);

                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            
                            Session["ProductAdded"] = "1";
                            return RedirectToAction("Display");
                        }
                        else
                        {
                            
                            return RedirectToAction("Error", "Account");
                        }
                    }

                }

                return View();



            }
            catch (Exception e)
            {
                
                return RedirectToAction("Error", "Account");
            }
        }
    }
}