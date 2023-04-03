using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductsMarket.Domain.Entities;
using ProductsMarket.Domain.Entities.Users;
using ProductsMarket.Service.Interfaces.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductsMarket.Service.Services.Common
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            this._config = config.GetSection("Jwt");
        }
        public string GenerateToken(Human human, string role)
        {
            var claims = new[]
           {
                new Claim("Id", human.Id.ToString()),
                new Claim("FullName", human.FullName),
                new Claim("PhoneNumber", human.PhoneNumber),
                new Claim(ClaimTypes.Role, $"{role}")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_config["Lifetime"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
