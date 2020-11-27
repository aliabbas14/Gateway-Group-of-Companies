using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SourceControlAssignment1.Models
{
    /*
     This is the model that binds with the registration form.
         */
    public class RegistrationFormModel
    {
        //public int registration_id { get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage ="First Name is required")]
        public string first_name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string last_name { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        public long phone { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public byte gender { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("password",ErrorMessage ="Password & Confirm Password doesn't match")]
        [DataType(DataType.Password)]
        public string confirm_password { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public string state { get; set; }

    }
}
