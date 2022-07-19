using System;

namespace Eternal.Models
{
    public class ContractUpdatingDto
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public DateTime Expiration { get; set; }

        public int ClientId { get; set; }
    }
}
