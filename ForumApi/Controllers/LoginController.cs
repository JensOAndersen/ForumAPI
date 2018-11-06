using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ForumApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ForumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private IConfiguration config;
        private ForumContext context;

        public LoginController(IConfiguration config, ForumContext context)
        {
            this.config = config;
            this.context = context;
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Login([FromBody] User value)
        {
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(value);

            if(user != null)
            {
                string tokenString = generateJSONWebToken(user);
                response = Ok(new { token = tokenString, user = user.UserId });
            }
            return response;
        }

        private string generateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim("DateJoined", user.CreationDate.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.NameId, user.UserId.ToString())
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Issuer"], claims, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User value)
        {
            User user = null;

            if (value.Name == "Jens-Ole")
            {
                user = context.Users.FirstOrDefault(u => u.Name == value.Name);
            }
            return user;
        }
    }
}
