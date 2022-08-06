using System;
using System.Collections.Generic;

namespace Eternal.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string? Cpf { get; set; }
        public string? Name { get; set; }
        public List<Dependent>? Dependents { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Rg { get; set; }
        public string? HouseNumber { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
