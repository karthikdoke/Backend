using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserMode.Usermodel;

namespace UserMode.Controllers
{
    
    [ApiController]
    
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        public IConfiguration _config;
        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin([FromBody] UserRegistation credentialsObj)
        {
            if (credentialsObj == null)
            {
                return NotFound(new
                {
                    success = 0,
                    message = "Please check your Credentials",
                    token = string.Empty
                });
            }
            else
            {
                var db = new UserDbContext();
                var user = db.UserRegistation.Where(a =>
                    a.UserName == credentialsObj.UserName
                    && a.Password == credentialsObj.Password
                    ).FirstOrDefault();
                var token = GenerateTokenUsingJwt(credentialsObj.UserName);
                if (user != null)
                {
                    return Ok(new
                    {
                        success = 1,
                        message = "Logged In Successfully",
                        token = token
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        success = 0,
                        message = "Please check your Credentials",
                        token = string.Empty
                    });
                }
            }
        }
        public string GenerateTokenUsingJwt(string userName)
        {
            var signinngKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(signinngKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwt = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(3)
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

    }
}
