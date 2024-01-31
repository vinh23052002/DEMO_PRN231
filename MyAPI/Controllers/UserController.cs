using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        MySaleDBContext context = new MySaleDBContext();

        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(context.Users.ToList());
        }

        [HttpGet("{account}")]
        public IActionResult getById(string account)
        {
            var user = context.Users.FirstOrDefault(p => p.Account.Equals(account));
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult insert(User user)
        {

            context.Users.Add(user);
            context.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult update(User user)
        {
            var data = context.Users.SingleOrDefault(p => p.Account.Equals(user.Account));
            if (data == null)
            {
                return NotFound();
            }
            data.Password = user.Password;
            data.Name = user.Name;
            data.Gender = user.Gender;
            data.Address = user.Address;

            context.Update(data);
            context.SaveChanges();
            //return CreatedAtAction(nameof(getById), category.CategoryId);
            return Ok(user);
        }

        [HttpDelete("{account}")]
        public IActionResult delete(string account)
        {
            var data = context.Users.SingleOrDefault(p => p.Account.Equals(account));
            if (data == null)
            {
                return NotFound();
            }
            context.Users.Remove(data);
            context.SaveChanges();
            return NoContent();
        }

        public class ChangePasswordBody
        {
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
        }
        [HttpPost("ChangePass/{account}")]
        public IActionResult changePass(string account, [FromBody] ChangePasswordBody body)
        {
            var data = context.Users.SingleOrDefault(p => p.Account.Equals(account));
            if (data == null)
            {
                return NotFound();
            }
            if (data.Password != body.OldPassword)
            {
                return BadRequest();
            }
            data.Password = body.NewPassword;
            context.SaveChanges();
            return NoContent();
        }

        public class UpdateInforBody
        {
            public string Name { get; set; }
            public bool Gender { get; set; }
            public string Address { get; set; }

        }
        [HttpPut("UpdateInfor/{account}")]
        public IActionResult updateInformation(string account, [FromBody] UpdateInforBody body)
        {
            var data = context.Users.SingleOrDefault(p => p.Account.Equals(account));
            if (data == null)
            {
                return NotFound();
            }
            data.Name = body.Name;
            data.Gender = body.Gender;
            data.Address = body.Address;

            context.Update(data);
            context.SaveChanges();
            return NoContent();
        }
    }
}
