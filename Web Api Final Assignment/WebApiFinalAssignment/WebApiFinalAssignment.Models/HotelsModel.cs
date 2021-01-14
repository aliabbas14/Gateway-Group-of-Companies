﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFinalAssignment.Models
{
    public class HotelsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Pincode { get; set; }

        public string ContactNumber { get; set; }

        public string ContactPerson { get; set; }

        public string Website { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }
}
