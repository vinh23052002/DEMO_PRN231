using Assignment1_HE163166.DTO;
using Assignment1_HE163166.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment1_HE163166.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MyProductContext context = new MyProductContext();


        [HttpGet]
        public IActionResult GetAllOrder()
        {
            var data = context.Orders
                .Include(p => p.Member)
                .Select(p => new OrderResponse
                {
                    OrderId = p.OrderId,
                    MemberId = p.MemberId,
                    Freight = p.Freight,
                    OrderDate = p.OrderDate,
                    RequireDate = p.RequireDate,
                    ShipperDate = p.ShipperDate,
                    OrderDetails = p.OrderDetails.Select(o => new OrderDetailResponse
                    {
                        OrderId = o.OrderId,
                        Discount = o.Discount,
                        ProductId = o.ProductId,
                        Quantity = o.Quantity,
                        UnitPrice = o.UnitPrice
                    }).ToList()
                }).ToList();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var data = context.Orders
                .Include(p => p.Member)
                .Select(p => new OrderResponse
                {
                    OrderId = p.OrderId,
                    MemberId = p.MemberId,
                    Freight = p.Freight,
                    OrderDate = p.OrderDate,
                    RequireDate = p.RequireDate,
                    ShipperDate = p.ShipperDate,
                    OrderDetails = p.OrderDetails.Select(o => new OrderDetailResponse
                    {
                        OrderId = o.OrderId,
                        Discount = o.Discount,
                        ProductId = o.ProductId,
                        Quantity = o.Quantity,
                        UnitPrice = o.UnitPrice
                    }).ToList()
                }).SingleOrDefault(a => a.OrderId == id);

            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPost]
        public IActionResult insert(OrderRequest order)
        {
            var data = new Order
            {
                OrderDate = order.OrderDate,
                Freight = order.Freight,
                MemberId = order.MemberId,
                RequireDate = order.RequireDate,
                ShipperDate = order.ShipperDate

            };
            var member = context.Members.SingleOrDefault(p => p.MemberId == order.MemberId);
            if (member == null) { return BadRequest(); }
            context.Orders.Add(data);
            context.SaveChanges();
            return Ok(order);
        }

        [HttpPut("{id}")]
        public IActionResult update(int id, OrderRequest order)
        {
            var data = context.Orders.SingleOrDefault(p => p.OrderId == id);
            if (data == null)
            {
                return NotFound();
            }

            data.MemberId = order.MemberId;
            data.OrderDate = order.OrderDate;
            data.RequireDate = order.RequireDate;
            data.ShipperDate = order.ShipperDate;
            data.Freight = order.Freight;


            context.Update(data);
            context.SaveChanges();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var data = context.Orders.Include(p => p.OrderDetails).SingleOrDefault(p => p.OrderId == id);
            if (data.OrderDetails == null) return BadRequest();
            if (data == null)
            {
                return NotFound();
            }
            try
            {
                context.Orders.Remove(data);
            }
            catch
            {
                return BadRequest();
            }
            context.SaveChanges();
            return NoContent();
        }
    }
}
