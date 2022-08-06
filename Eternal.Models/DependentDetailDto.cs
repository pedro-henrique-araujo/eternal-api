using System;

namespace Eternal.Models
{
    public class DependentDetailDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int ClientId { get; set; }

        public DateTime BirthDate { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
    }
}
