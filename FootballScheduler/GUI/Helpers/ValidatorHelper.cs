using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GUI.Helpers
{
    public static class ValidatorHelper
    {
        public static bool TryValidate(object obj, out string errorMessage)
        {
            var context = new ValidationContext(obj);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, context, results, true);
            errorMessage = isValid ? null : results.First().ErrorMessage;
            return isValid;
        }
    }
}
