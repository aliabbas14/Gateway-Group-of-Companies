using DotNetAssignment.DAL.Interface;
using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignment.DAL
{
    public class AdminAppointmentRepo : IAdminAppointmentRepo
    {

        /*
            This method is called when the admin rejects the appointment for what so ever reason. It changes the value of 
            status field.
         */
        public void GetDisapprove(int id)
        {
            using (var context = new DotNetAssignmentEntities())
            {
                var data=context.Services.Where(x => x.Id == id).FirstOrDefault();
                data.Status = true;
                context.SaveChanges();
            }
        }

        /*
           This method is called when admin clicks on edit button of the list of appointments. It opens the form with the details
           filled.s
        */
        public object Edit(int id)
        {
            using (var context = new DotNetAssignmentEntities())
            {
                var data = context.Services.Where(x => x.Id == id).FirstOrDefault();
                return data;
            }
        }

        /*
            This method is called when admin edits the appointment and clicks on the submit button. It collects the data and edits
            the data in the database.
         */

        public void Edit(AdminAppointment model)
        {
            using (var context = new DotNetAssignmentEntities())
            {
                var data = context.Services.Where(x => x.Id == model.Id).FirstOrDefault();
                data.Title = model.Title;
                data.Price = Convert.ToDecimal(model.Price);

            }
        }

        /*
        This method is called when admin wants to see all the appointments that are booked by the customers. It returns list of 
       booked appointments.
        */
        public List<Service> Get()
        {
            using (var context = new DotNetAssignmentEntities())
            {
                var data = context.Services.Select(x => new Service()
                {
                    Id=x.Id,
                    Title=x.Title,
                    Price=x.Price,
                    date=x.date,
                    Status=x.Status
                }).ToList();
                return data;

            }
        }

        List<object> IAdminAppointmentRepo.Get()
        {
            throw new NotImplementedException();
        }
    }
}
