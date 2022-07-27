using System;
using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    public class ClientDetailDto
    {
        public int Id { get; set; }
        public string? Cpf { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
