using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectTraineeAssignment.Models
{
    public class ProductModel
    {
        public int id { get; set; }

        [Display(Name ="Product Name")]
        [Required]
        public string name { get; set; }

        [Required]  
        public virtual CategoryModel category { get; set; }

        [Display(Name = "Price")]
        [Required]
        public int price { get; set; }

        [Display(Name = "Quantity")]
        [Required]
        public int quantity { get; set; }

        [Display(Name = "Short Description")]
        [Required]
        public string short_description { get; set; }

        [Display(Name = "Long Description")]
        public string long_description { get; set; }

        [Display(Name = "Small Image")]
        [Required]
        public string small_image { get; set; }

        [Display(Name = "Large Image")]
        public string large_image { get; set; }
    }
}
