using System;
using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    public class ClientUpdatingDto
    {
        [Required, Range(1, (double)decimal.MaxValue)]
        public int Id { get; set; }

        [Required, Cpf]
        public string? Cpf { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required, ClientBirthDate, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
