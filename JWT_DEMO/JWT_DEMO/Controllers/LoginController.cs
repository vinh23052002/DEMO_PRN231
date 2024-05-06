using JWT_DEMO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_DEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        private User AuthenticateUser(User user)
        {
            User _user = null;
            if (user.Username == "admin" && user.Password == "admin")
            {
                _user = new User { Username = "admin", Password = "admin" };
            }
            else if (user.Username == "user" && user.Password == "user")
            {
                _user = new User { Username = "user", Password = "user" };
            }

            return _user;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // add user info to token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(ClaimTypes.Role, userInfo.Username),

            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);



        }

        [AllowAnonymous]
        [HttpPost]

        public IActionResult Login([FromBody] User login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [Authorize]
        [HttpGet("GetInforUser")]
        public IActionResult GetInforUser()
        {
            //get user from token in header 
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return Ok(new User()
            {
                Username = userName,
            });
        }
        [Authorize(Roles = "admin")]
        [HttpGet("GetInforAdmin")]
        public IActionResult GetInforAdmin()
        {
            //get user from token in header 
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return Ok(new User()
            {
                Username = userName,
            });
        }
    }
}
