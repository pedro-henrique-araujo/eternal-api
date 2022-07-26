using System;
using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    public class InstalmentDetailDto
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Expiration { get; set; }

        public decimal Value { get; set; }

        public int ContractId { get; set; }

        public InstalmentStatus InstalmentStatus { get; set; }
    }
}
