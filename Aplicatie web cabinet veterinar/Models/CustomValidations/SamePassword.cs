using Aplicatie_web_cabinet_veterinar.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicatie_web_cabinet_veterinar.Models.CustomValidations
{
	public class SamePassword : ValidationAttribute
	{
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (UserSignUpModel)validationContext.ObjectInstance;
            if (user == null || user.Password != user.ConfirmPassword)
                return new ValidationResult("Parola nu coincide");

            return ValidationResult.Success;
        }
    }
}