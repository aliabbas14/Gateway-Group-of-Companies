using DotNetAssignment.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetAssignment.Models;
using DotNetAssignment.DAL.Interface;

namespace DotNetAssignment.BAL
{
    public class AdminAppointment : IAdminAppointment
    {
        IAdminAppointmentRepo _admin;
        public AdminAppointment(IAdminAppointmentRepo admin)
        {
            _admin = admin;
        }

        /*
            This method is called when the admin rejects the appointment for what so ever reason. It changes the value of 
            status field.
         */

        public void GetDisapprove(int id)
        {
            _admin.GetDisapprove(id);
        }

        /*
           This method is called when admin clicks on edit button of the list of appointments. It opens the form with the details
           filled.s
        */

        public object Edit(int id)
        {
            return _admin.Edit(id);
        }


        /*
            This method is called when admin edits the appointment and clicks on the submit button. It collects the data and edits
            the data in the database.
         */
        public void PostEdit(DotNetAssignment.Models.AdminAppointment model)
        {
            _admin.Edit(model);
        }

        /*
        This method is called when admin wants to see all the appointments that are booked by the customers. It returns list of 
       booked appointments.
        */
        public List<object> Get()
        {
            return _admin.Get();
        }
    }
}
