using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DemoApp.Application.ApiValidation
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ValidClientCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var clientCode = value as string;

            if (clientCode != null)
            {
                var regex = new Regex(@"^[a-zA-Z]{1,10}$");

                if (regex.IsMatch(clientCode))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult($"Invalid customer reference: {clientCode}");
        }
    }
}
