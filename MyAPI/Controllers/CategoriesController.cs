using Microsoft.AspNetCore.Mvc;
using MyAPI.DTO;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        MySaleDBContext context = new MySaleDBContext();

        [HttpGet]
        public IActionResult getAll()
        {

            var response = context.Categories
                .ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var category = context.Categories.FirstOrDefault(p => p.CategoryId == id);
            if (category == null)
            {
                return BadRequest();
            }
            return Ok(category);
        }

        public class InsertCategoryBody
        {
            public string CategoryName { get; set; }
        }
        [HttpPost]
        public IActionResult insert(InsertCategoryBody body)
        {
            context.Categories.Add(new Category { CategoryName = body.CategoryName });
            context.SaveChanges();
            return Ok(getAll());
        }

        [HttpPut]
        public IActionResult update(CategoryRequest category)
        {
            var data = context.Categories.SingleOrDefault(p => p.CategoryId == category.CategoryId);
            if (data == null)
            {
                return NotFound();
            }
            data.CategoryName = category.CategoryName;
            context.Update(data);
            context.SaveChanges();
            //return CreatedAtAction(nameof(getById), category.CategoryId);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var data = context.Categories.SingleOrDefault(p => p.CategoryId == id);
            if (data == null)
            {
                return NotFound();
            }
            context.Categories.Remove(data);
            context.SaveChanges();
            return NoContent();
        }
    }
}