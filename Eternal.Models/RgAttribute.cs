using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Eternal.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class RgAttribute : ValidationAttribute
    {
        public RgAttribute()
        {
            ErrorMessage = "The {0} field must only contain exaclty 11 digits";
        }

        public override bool IsValid(object value)
        {
            if (value is null) return true;
            if (value is string inputValue)
            {
                if (inputValue.Length != 11) return false;

                var numericRegex = @"^\d+$";
                return Regex.IsMatch(inputValue, numericRegex);
            }

            return false;
        }
    }
}
