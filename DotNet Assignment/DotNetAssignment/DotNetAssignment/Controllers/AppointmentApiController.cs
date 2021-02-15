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
    public class AppointmentApiController : ApiController
    {
        IAppointment _app;
        public AppointmentApiController(IAppointment app)
        {
            _app = app;

        }

        /*
            This method is called when user books an appointment. It collects the data of the form and calls the api
         */
        public IHttpActionResult PostBooking(BookAppointment model)
        {
            _app.PostBooking(model);
            return Ok();
        }
    }
}
