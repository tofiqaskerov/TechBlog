using Core.Entity.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Jwt
{
    public static class TokenGenerator
    {
        public static string Token(User user, string role)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("qsegrgserhwerhw5rhw5hw56wafq4wgo4gaoEagaEFgAege");
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, role),
                }),
                Expires = DateTime.UtcNow.AddMinutes(2),    
                SigningCredentials  = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
                Issuer = "ComparAcademy",
                Audience = "ComparAcademy"

            };
            var token = jwtHandler.CreateToken(tokenDescription);
            return jwtHandler.WriteToken(token);
        }
    }
}
