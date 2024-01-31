using Assignment1_HE163166.DTO;
using Assignment1_HE163166.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment1_HE163166.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly MyProductContext context = new MyProductContext();


        [HttpGet]
        public IActionResult GetAllProductDetails()
        {
            var data = context.OrderDetails.Include(p => p.Product)
                .Select(p => new OrderDetailResponse
                {
                    Discount = p.Discount,
                    OrderId = p.OrderId,
                    ProductId = p.ProductId,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice,
                });
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var data = context.OrderDetails.Where(p => p.OrderId == id)
                .Select(p => new OrderDetailResponse
                {
                    Discount = p.Discount,
                    OrderId = p.OrderId,
                    ProductId = p.ProductId,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice,
                });
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPost]
        public IActionResult insert(OrderDetailRequest p)
        {
            var data = new OrderDetail
            {
                Discount = p.Discount,
                OrderId = p.OrderId,
                ProductId = p.ProductId,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
            };
            context.OrderDetails.Add(data);
            context.SaveChanges();
            return Ok(data);
        }

        public class getKey
        {
            public int OrderId { get; set; }
            public int ProductId { get; set; }
        }
        [HttpPut]
        public IActionResult update(OrderDetailRequest p)
        {
            var data = new OrderDetail
            {
                Discount = p.Discount,
                OrderId = p.OrderId,
                ProductId = p.ProductId,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
            };
            context.OrderDetails.Update(data);
            context.SaveChanges();
            return Ok(data);
        }

        [HttpDelete]
        public IActionResult delete(getKey key)
        {
            var data = context.OrderDetails.SingleOrDefault(p => p.OrderId == key.OrderId && p.ProductId == key.ProductId);
            if (data == null)
            {
                return NotFound();
            }
            context.OrderDetails.Remove(data);
            context.SaveChanges();
            return NoContent();
        }
    }
}

