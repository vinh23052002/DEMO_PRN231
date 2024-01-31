using System;
using System.Collections.Generic;

namespace Assignment1_HE163166.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string? ProductName { get; set; }
        public double? Weight { get; set; }
        public double? UnitPrice { get; set; }
        public int? UnitInStock { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
