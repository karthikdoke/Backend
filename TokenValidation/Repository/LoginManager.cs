using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TokenValidation.IRepository;

namespace TokenValidation.Repository
{
    public class LoginManager: Ilogin
    {
        

        public string Builder(string userName)
        {
            var signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hbfifh8fuqiOA3FUKtQAvn6dgegiWbT"));
            var signingCredentials = new SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userName)
            };
            var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;

        }
    }
}
