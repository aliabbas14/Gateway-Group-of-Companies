using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DotNetAssignment.Models
{
    public class AdminAppointment
    {

        public int Id { get; set; }

        [DisplayName("Customer Name" )]
        public string CustomerName { get; set; }

        [DisplayName("Customer Phone")]
        public string CustomerPhone { get; set; }

        [DisplayName("Vehicle Brand")]
        public string VehicleBrand { get; set; }

        [DisplayName("Vehicle Model")]
        public string VehicleModel { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        [DisplayName("Requested Date")]
        public string RequestedDate { get; set; }

        public string Description { get; set; }

    }
}
