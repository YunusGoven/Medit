using System;
using System.ComponentModel.DataAnnotations;

namespace Medit1.Validation
{
    public class CruiseDateVerificationAttribute : ValidationAttribute
    {
        private readonly string _propertyName;

        public CruiseDateVerificationAttribute(string propertyName)
        {
            _propertyName = propertyName;
        }

        protected override ValidationResult IsValid(object firstValue, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_propertyName);
            
            var propertyValue = propertyInfo?.GetValue(validationContext.ObjectInstance, null);


            return propertyValue != null && (DateTime) propertyValue < (DateTime) firstValue ? ValidationResult.Success : new ValidationResult("La date est mauvaise");
        }
    }
}
