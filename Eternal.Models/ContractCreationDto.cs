using System;
using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    public class ContractCreationDto
    {
        [Required, Range(1, (double)decimal.MaxValue)]
        public decimal Value { get; set; }

        [Required, ExpirationDate, DataType(DataType.Date)]
        public DateTime Expiration { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int ClientId { get; set; }
    }
}
