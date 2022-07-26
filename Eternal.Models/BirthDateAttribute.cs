using System;
using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class BirthDateAttribute : ValidationAttribute
    {
        public BirthDateAttribute()
        {
            ErrorMessage = "The {0} field must not be greater than or equal to today";
        }

        public override bool IsValid(object value)
        {
            if (value is null) return true;
            if (value is DateTime inputValue)
            {
                return inputValue < DateTime.Today;
            }
            return true;
        }
    }
}
