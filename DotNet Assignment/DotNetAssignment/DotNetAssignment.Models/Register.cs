using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace DotNetAssignment.Models
{
    public class Register
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [DisplayName("Home Phone")]
        public string HomePhone { get; set; }

        [DisplayName("Password")]
        public string Pwd { get; set; }

        [DisplayName("Address 1")]
        public string Address1 { get; set; }

        [DisplayName("Address 2")]
        public string Address2 { get; set; }
        public string Zipcode { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public System.DateTime RegDate { get; set; }
        public string ChassisNo { get; set; }
    }
}
