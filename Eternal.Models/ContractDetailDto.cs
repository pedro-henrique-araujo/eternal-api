using System;
using System.Collections.Generic;

namespace Eternal.Models
{
    public class ContractDetailDto
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public DateTime Expiration { get; set; }

        public int ClientId { get; set; }

        public ClientDetailDto? Client { get; set; }

        public List<InstalmentDetailDto>? Instalments { get; set; }
    }
}
