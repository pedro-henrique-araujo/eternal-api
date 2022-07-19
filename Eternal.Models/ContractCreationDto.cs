using System;

namespace Eternal.Models
{
    public class ContractCreationDto
    {
        public decimal Value { get; set; }

        public DateTime Expiration { get; set; }

        public int ClientId { get; set; }
    }
}
