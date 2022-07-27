using System;
using System.Collections.Generic;

namespace Eternal.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public DateTime Expiration { get; set; }

        public int ClientId { get; set; }

        public Client? Client { get; set; }

        public int ContractTemplateId { get; set; }

        public ContractTemplate? ContractTemplate { get; set; }

        public List<Instalment>? Instalments { get; set; }

    }
}
