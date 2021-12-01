using RtmLib.Addresses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RtmLib.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SpecialAddressAttribute : ValidationAttribute
    {
        public int MaxLength { get; set; }
        public string RegualrExpressionValidation { get; set; }
        public bool AddressWithVal { get; set; }
        public string ErrorMassage { get; set; }
        private const string defaultErrorMassage = "Ошибка валдиации";
        private const string defaultErrorMassageCast = "Ошибка валдиации. Невозможность приведения";
        private const string defaultErrorMassageRegEx = "Ошибка валдиации. Ошибка проверки регулярного выражения";
        private const string defaultErrorMassageMaxLength = "Ошибка валдиации. Ошибка длины строки";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(!(value is null))
            {
                var checkAttribute = value as AddressElement;

                if(checkAttribute is null)
                {
                    return new ValidationResult(ErrorMassage ?? defaultErrorMassageCast);
                }
                var regEx = new Regex(RegualrExpressionValidation ?? "");
                if (!(RegualrExpressionValidation is null)
                    &&
                    !regEx.IsMatch(checkAttribute.AddressString))
                {
                    return new ValidationResult(ErrorMassage ?? defaultErrorMassageRegEx);
                }
                var checkLength = !AddressWithVal ? checkAttribute.AddressString : checkAttribute.ToString();
                if (checkLength.Length > MaxLength && MaxLength != 0)
                {
                    return new ValidationResult(ErrorMassage ?? defaultErrorMassageMaxLength);
                }
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMassage ?? defaultErrorMassage);
            }

        }


    }
}
