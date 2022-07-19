﻿using System;

namespace Eternal.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public DateTime Expiration { get; set; }

        public int ClientId { get; set; }

        public Client? Client { get; set; }
    }
}