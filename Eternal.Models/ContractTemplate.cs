using System.Collections.Generic;

namespace Eternal.Models
{
    public class ContractTemplate
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Text { get; set; }

        public List<Contract>? Contracts { get; set; }
    }
}
