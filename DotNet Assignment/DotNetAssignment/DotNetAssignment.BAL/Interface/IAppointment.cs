using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignment.BAL.Interface
{
    public interface IAppointment
    {
        /*
            This method is called when user books an appointment. It collects the data of the form and calls the api
         */
        void PostBooking(BookAppointment model);
    }
}
