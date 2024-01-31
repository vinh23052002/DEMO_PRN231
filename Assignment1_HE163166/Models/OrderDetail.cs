using System;
using System.Collections.Generic;

namespace Assignment1_HE163166.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public int? Discount { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
