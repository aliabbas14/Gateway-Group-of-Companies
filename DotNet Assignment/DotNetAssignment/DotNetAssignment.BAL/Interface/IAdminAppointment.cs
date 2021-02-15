using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignment.BAL.Interface
{
    public interface IAdminAppointment
    {
        /*
        This method is called when admin wants to see all the appointments that are booked by the customers. It returns list of 
       booked appointments.
        */
        List<Object> Get();

        /*
           This method is called when admin clicks on edit button of the list of appointments. It opens the form with the details
           filled.s
        */
        Object Edit(int id);

        /*
            This method is called when admin edits the appointment and clicks on the submit button. It collects the data and edits
            the data in the database.
         */
        void PostEdit(DotNetAssignment.Models.AdminAppointment model);

        /*
            This method is called when the admin rejects the appointment for what so ever reason. It changes the value of 
            status field.
         */
        void GetDisapprove(int id);
    }
}
