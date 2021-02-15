using DotNetAssignment.DAL.Interface;
using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignment.DAL
{
    public class AppointmentRepo : IAppointmentRepo
    {

        /*
            This method is called when user books an appointment. It collects the data of the form and calls the api
         */
        public void PostBooking(BookAppointment model)
        {
            using (var context = new DotNetAssignmentEntities())
            {
                var data = new Service()
                {
                    Title=model.Title,
                    Description=model.Description
                };
                context.Services.Add(data);
                context.SaveChanges();
            }
        }
    }
}
