using System;

namespace Eternal.Models
{
    public class ClientDetailDto
    {
        public int Id { get; set; }
        public string? Cpf { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
