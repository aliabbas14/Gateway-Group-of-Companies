using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectTraineeAssignment.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string email { get; set; }

        public string phone { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must contain at least eight characters, one upper case, one lower case, one number & one special character ")]
        public string pwd { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("pwd", ErrorMessage = "Password & Confirm Password doesn't match")]
        public string confirm_pwd { get; set; }
    }
}
