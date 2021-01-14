using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFinalAssignment.Models
{
    public class BookingsModel
    {
        public int Id { get; set; }

        public DateTime date { get; set; }

        public int RoomId { get; set; }

        public string Status { get; set; }
    }
}
