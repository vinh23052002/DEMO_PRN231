using System;
using System.Collections.Generic;

namespace DEMO_PRN231_SE1627.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public bool Gender { get; set; }
        public string? Address { get; set; }
    }
}
