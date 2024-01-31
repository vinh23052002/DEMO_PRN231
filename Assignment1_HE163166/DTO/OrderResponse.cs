namespace Assignment1_HE163166.DTO
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public int? MemberId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequireDate { get; set; }
        public DateTime? ShipperDate { get; set; }
        public double? Freight { get; set; }

        public virtual ICollection<OrderDetailResponse> OrderDetails { get; set; }
    }
}
