using System;
using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    public class DependentCreationDto
    {
        [Required, StringLength(150, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int ClientId { get; set; }

        [Required, BirthDate, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required, Cpf]
        public string? Cpf { get; set; }

        [Required, Rg]
        public string? Rg { get; set; }
    }
}
