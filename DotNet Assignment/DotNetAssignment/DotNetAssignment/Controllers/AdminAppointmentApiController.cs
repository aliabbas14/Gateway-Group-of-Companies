using DotNetAssignment.BAL.Interface;
using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotNetAssignment.Controllers
{
    public class AdminAppointmentApiController : ApiController
    {
        IAdminAppointment _admin;
        public AdminAppointmentApiController(IAdminAppointment admin)
        {
            _admin = admin;
        }

        /*
        This method is called when admin wants to see all the appointments that are booked by the customers. It returns list of 
       booked appointments.
        */
        public IHttpActionResult Get()
        {
            return Ok(_admin.Get());
        }

        /*
           This method is called when admin clicks on edit button of the list of appointments. It opens the form with the details
           filled.s
        */
        public IHttpActionResult Edit(int id)
        {
            return Ok(_admin.Edit(id));
        }

        /*
            This method is called when admin edits the appointment and clicks on the submit button. It collects the data and edits
            the data in the database.
         */
        public IHttpActionResult Edit(AdminAppointment model)
        {
            _admin.PostEdit(model);
            return Ok();
        }

        /*
            This method is called when the admin rejects the appointment for what so ever reason. It changes the value of 
            status field.
         */
        public IHttpActionResult GetDisapprove(int id)
        {
            _admin.GetDisapprove(id);
            return Ok();
        }
    }
}