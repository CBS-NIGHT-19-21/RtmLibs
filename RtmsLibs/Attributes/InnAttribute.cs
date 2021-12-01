using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RtmLib.Attributes
{
    /// <summary>
    /// Валидация ИНН
    /// </summary>
    public class InnAttribute : ValidationAttribute
    {
        private const int minLength = 10;
        private const int maxLength = 12;
        private Regex innRegEx = new Regex(@"\d{10,12}");
        private const string innErrorRegexMassage = "Ошибка при роверке ИНН. Ошибка Валидации по регулярному выражения";
        private const string innErrorLengthMassage = "Ошибка при проверке ИНН. Ошибка валидации по длине ИНН";

        public string ErrorMassage { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value.ToString().Length != minLength || value.ToString().Length != maxLength)
            {
                return new ValidationResult(ErrorMassage ?? innErrorLengthMassage);
            }
            if(!innRegEx.IsMatch(value.ToString()))
            {
                return new ValidationResult(ErrorMassage ?? innErrorRegexMassage);
            }
            return ValidationResult.Success;


        }

    }
}
