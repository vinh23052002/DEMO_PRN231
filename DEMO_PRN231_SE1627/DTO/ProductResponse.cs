namespace DEMO_PRN231_SE1627.DTO
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public string? Image { get; set; }
        public int? CategoryId { get; set; }

        public CategoryResponse categoryResponse { get; set; }
    }
}
