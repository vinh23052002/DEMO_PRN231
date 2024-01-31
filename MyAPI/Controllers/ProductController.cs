using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.DTO;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        MySaleDBContext context = new MySaleDBContext();

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = context.Products.Include(p => p.Category)
                .Select(p => new ProductResponse()
                {
                    ProductId = p.ProductId,
                    CategoryId = p.CategoryId,
                    ProductName = p.ProductName,
                    Image = p.Image,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    categoryResponse = new CategoryResponse()
                    {
                        CategoryId = p.CategoryId,
                        CategoryName = p.Category.CategoryName
                    }
                });
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var p = context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);

            var product = new ProductResponse
            {
                ProductId = p.ProductId,
                CategoryId = p.CategoryId,
                ProductName = p.ProductName,
                Image = p.Image,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                categoryResponse = new CategoryResponse()
                {
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.CategoryName
                }
            };

            if (product == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult insert(ProductRequest product)
        {
            Product newProduct = new Product()
            {
                CategoryId = product.CategoryId,
                Image = product.Image,
                UnitPrice = product.UnitPrice,
                ProductName = product.ProductName,
                UnitsInStock = product.UnitsInStock
            };

            context.Products.Add(newProduct);
            context.SaveChanges();

            return Ok(newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult update(int id, [FromBody] ProductRequest product)
        {
            var data = context.Products.SingleOrDefault(p => p.ProductId == id);
            if (data == null)
            {
                return NotFound();
            }
            data.ProductName = product.ProductName;
            data.UnitPrice = product.UnitPrice;
            data.UnitsInStock = product.UnitsInStock;
            data.Image = product.Image;
            data.CategoryId = product.CategoryId;
            context.Update(data);
            context.SaveChanges();
            //return CreatedAtAction(nameof(getById), category.CategoryId);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var data = context.Products.SingleOrDefault(p => p.ProductId == id);
            if (data == null)
            {
                return NotFound();
            }
            context.Products.Remove(data);
            context.SaveChanges();
            return NoContent();
        }
    }
}
