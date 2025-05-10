using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Interface.Dtos;
using ToDoList.Interface.IRepositories;

namespace ToDoList.Infrastructure.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JWT _jwt;

        public JwtTokenGenerator(IOptions<JWT> jwt)
        {
            _jwt = jwt.Value;
        }
        public string GenerateJwtToken(LoginModelDto user)
        {

            IEnumerable<Claim> Claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Email,user.Email ?? ""),
                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                 
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurity = new(

                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                expires: DateTime.UtcNow.AddHours(2),
                claims: Claims,
                signingCredentials: signingCredentials

            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurity);

            return token;


        }
    }
}
