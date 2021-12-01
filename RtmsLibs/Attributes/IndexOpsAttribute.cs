using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RtmLib.Attributes
{
    class IndexOpsAttribute : ValidationAttribute
    {
        private int lengthIndex = 6;
        private Regex indexPattern = new Regex(@"\d{6,6}");

        private const string indexErrorRegexMassage = "Ошибка при роверке ИНН. Ошибка Валидации по регулярному выражения";
        private const string indexErrorLengthMassage = "Ошибка при проверке ИНН. Ошибка валидации по длине ИНН";

        public string ErrorMassage { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString().Length != lengthIndex)
            {
                return new ValidationResult(ErrorMassage ?? indexErrorLengthMassage);
            }
            if (!indexPattern.IsMatch(value.ToString()))
            {
                return new ValidationResult(ErrorMassage ?? indexErrorRegexMassage);
            }
            return ValidationResult.Success;


        }
    }
}
