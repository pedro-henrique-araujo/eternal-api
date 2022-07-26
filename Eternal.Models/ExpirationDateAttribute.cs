using System;
using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ExpirationDateAttribute : ValidationAttribute
    {
        public ExpirationDateAttribute()
        {
            ErrorMessage = "The {0} field must not be less than 30 days ahead";
        }

        public override bool IsValid(object value)
        {
            if (value is null) return true;
            if (value is DateTime inputValue)
            {
                return inputValue >= DateTime.Today.AddDays(30);
            }
            return true;
        }
    }
}
