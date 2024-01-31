namespace Assignment1_HE163166.DTO
{
    public class OrderDetailResponse
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public int? Discount { get; set; }
    }
}
