using System;
using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    public class ClientCreationDto
    {
        [Required, Cpf]
        public string? Cpf { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required, ClientBirthDate, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required, Rg]
        public string? Rg { get; set; }

        [Required, StringLength(150)]
        public string? HouseNumber { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public string? Street { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public string? Neighborhood { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public string? City { get; set; }

        [Required, StringLength(150, MinimumLength = 5)]
        public string? PhoneNumber { get; set; }
    }
}
