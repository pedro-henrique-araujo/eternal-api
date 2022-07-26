using System;
using System.ComponentModel.DataAnnotations;

namespace Eternal.Models
{
    public class ContractPaginationDto
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        [DataType(DataType.Date)]
        public DateTime Expiration { get; set; }
    }
}
