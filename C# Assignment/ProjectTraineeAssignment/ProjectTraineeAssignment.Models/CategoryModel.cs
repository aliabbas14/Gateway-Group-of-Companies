using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectTraineeAssignment.Models
{
    public class CategoryModel
    {
        public int id { get; set; }
        
        [Display(Name ="Category Name")]
        public string name { get; set; }
    }
}
