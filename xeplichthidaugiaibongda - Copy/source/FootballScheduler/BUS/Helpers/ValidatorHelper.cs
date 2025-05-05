using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BUS.Helpers
{
    public static class ValidatorHelper
    {
        /// <summary>
        /// Kiểm tra tính hợp lệ của đối tượng và trả về lỗi đầu tiên (nếu có).
        /// </summary>
        public static bool TryValidate(object instance, out string firstError)
        {
            firstError = null;

            // Nếu đối tượng là null, trả về false và không kiểm tra tiếp
            if (instance == null)
            {
                return false;
            }

            // Danh sách lưu trữ kết quả kiểm tra
            var validationResults = new List<ValidationResult>();

            // Kiểm tra tính hợp lệ của đối tượng và lưu kết quả vào validationResults
            bool isValid = Validator.TryValidateObject(instance, new ValidationContext(instance), validationResults, validateAllProperties: true);

            // Lấy lỗi đầu tiên (nếu có)
            firstError = validationResults.FirstOrDefault()?.ErrorMessage;

            return isValid;
        }
    }
}
