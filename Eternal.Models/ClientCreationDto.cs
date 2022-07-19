using System;

namespace Eternal.Models
{
    public class ClientCreationDto
    {
        public string? Cpf { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
