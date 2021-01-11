using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControlFinalAssignment.Models
{
    /*
        This is the model class for registration form.
         */
    public class RegistrationModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [CustomValidations]
        public DateTime dob { get; set; }

        [Required]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$",ErrorMessage ="Password must be atleast 8 characters & contain atleast one number, one uppercase & one lower case")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password & Confirm Password doesn't match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(18,100,ErrorMessage ="Age should be between 18 and 100")]
        public int Age { get; set; }


        public int Gender { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }


        public HttpPostedFileBase photo { get; set; }
    }
}
