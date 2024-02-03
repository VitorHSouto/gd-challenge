using gd_api.Domain.Settings;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace gd_api.Domain.Services
{
    public class JwtService
    {
        public JwtService() { }

        private readonly string Key = Context.JwtSecret;

        public string GenerateToken(string email)
        {
            var secret = Encoding.ASCII.GetBytes(Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Email, email) })
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
