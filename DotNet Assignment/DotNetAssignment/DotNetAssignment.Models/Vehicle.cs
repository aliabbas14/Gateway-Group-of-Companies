using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignment.Models
{
    class Vehicle
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public System.DateTime RegDate { get; set; }
        public string ChassisNo { get; set; }
    }
}
