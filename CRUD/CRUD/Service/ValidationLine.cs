using CRUD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Service
{
    public static class ValidationLine
    {

        public static string Validation(User contextUser)
        {
            var error = string.Empty;
            var validationContext = new ValidationContext(contextUser);
            var validationResult = new List<ValidationResult>();
            if (!Validator.TryValidateObject(contextUser, validationContext, validationResult))
            {
                foreach (var item in validationResult)
                {
                    error+= item.ErrorMessage +"\n";
                }
            }
            return error;
        }
    }
}
