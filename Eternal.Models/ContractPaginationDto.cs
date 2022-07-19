using System;

namespace Eternal.Models
{
    public class ContractPaginationDto
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public DateTime Expiration { get; set; }

        public Client? Client { get; set; }
    }
}
