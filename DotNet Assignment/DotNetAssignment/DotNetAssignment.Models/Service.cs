using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignment.Models
{
    class Service
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int MechanicId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public System.DateTime date { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
