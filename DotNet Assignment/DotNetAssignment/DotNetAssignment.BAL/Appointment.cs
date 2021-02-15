using DotNetAssignment.BAL.Interface;
using DotNetAssignment.DAL.Interface;
using DotNetAssignment.DAL;
using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignment.BAL
{
    public class Appointment : IAppointment
    {
        IAppointmentRepo _app;
        public Appointment(IAppointmentRepo app)
        {
            _app = app;
        }

        /*
            This method is called when user books an appointment. It collects the data of the form and calls the api
         */
        public void PostBooking(BookAppointment model)
        {
            _app.PostBooking(model);
        }
    }
}
