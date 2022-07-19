using System;

namespace Eternal.Models
{
    public class InstalmentDetailDto
    {
        public int Id { get; set; }

        public DateTime? Expiration { get; set; }

        public decimal Value { get; set; }

        public int ContractId { get; set; }

        public Contract? Contract { get; set; }
    }
}
