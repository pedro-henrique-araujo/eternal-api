using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    public class ContractDetailDto
    {
        [Required, Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required, Range(1, (double)decimal.MaxValue)]
        public decimal Value { get; set; }

        [DataType(DataType.Date)]
        public DateTime Expiration { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int ClientId { get; set; }
    }
}
