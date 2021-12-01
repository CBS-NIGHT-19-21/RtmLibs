using RtmLib.Barcodes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtmLib.Attributes
    
{
    /// <summary>
    /// Аттрибут на ШПИ отпавления
    /// </summary>
    public class BarcodeAttribute : ValidationAttribute
    {
        public string ErrorMassage { get; set; }
        private const string errorMassage = "Ошибка валидации ШПИ";
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(BarcodeClass.CheckBarcode(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMassage ?? errorMassage);

        }


    }
}
