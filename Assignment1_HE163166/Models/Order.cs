namespace Assignment1_HE163166.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? MemberId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequireDate { get; set; }
        public DateTime? ShipperDate { get; set; }
        public double? Freight { get; set; }

        public virtual Member? Member { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
