using System;

namespace Eternal.Models
{
    public class ClientPaginationDto
    {
        public int Id { get; set; }
        public string? Cpf { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
