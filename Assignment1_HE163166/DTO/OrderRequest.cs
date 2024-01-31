namespace Assignment1_HE163166.DTO
{
    public class OrderRequest
    {
        public int? MemberId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequireDate { get; set; }
        public DateTime? ShipperDate { get; set; }
        public double? Freight { get; set; }
    }
}
