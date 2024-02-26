using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

using WebApplication4.Utility;
namespace WebApplication4.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required!!")]
        [RejectName("vu khi")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "UnitPrice is required!!")]
        [Range(0, 999.99, ErrorMessage = "UnitPrice is outside the range from 0 to 999.99")]
        public decimal? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }
        public string? Image { get; set; }
        public int? CategoryId { get; set; }

        [ValidateNever]
        public virtual Category? Category { get; set; }
    }
}
