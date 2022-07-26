using System;
using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ClientBirthDateAttribute : ValidationAttribute
    {
        public ClientBirthDateAttribute()
        {
            ErrorMessage = "The {0} field must not be greater than 18 years behind";
        }

        public override bool IsValid(object value)
        {
            if (value is null) return true;
            if (value is DateTime inputValue)
            {
                return inputValue < DateTime.Today.AddYears(-18);
            }
            return true;
        }
    }
}
