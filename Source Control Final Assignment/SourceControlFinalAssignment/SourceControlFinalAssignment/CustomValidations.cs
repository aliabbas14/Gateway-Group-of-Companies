using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControlFinalAssignment
{
    public class CustomValidations:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                
                if (Convert.ToDateTime(value) <= DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Date of Birth cannot be future date");
                }
            }
            return new ValidationResult("Date of Birth is required");
        }
    }
}
