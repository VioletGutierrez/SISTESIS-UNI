using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistesisUni.Core.Application.DTOs;
using SistesisUni.Core.Application.Interfaces;

namespace SistesisUni.Infrastructure.Security
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config) => _config = config;

        public LoginResponseDto GenerateToken(string username)
        {
            var key = _config["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key no configurado");
            var issuer = _config["Jwt:Issuer"] ?? "SistesisUni";
            var audience = _config["Jwt:Audience"] ?? "SistesisUniUsers";
            var expiresMinutes = int.Parse(_config["Jwt:ExpirationMinutes"] ?? "60");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Estudiante")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expiresAt = DateTime.UtcNow.AddMinutes(expiresMinutes);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiresAt,
                signingCredentials: credentials
            );

            return new LoginResponseDto(
                new JwtSecurityTokenHandler().WriteToken(token),
                username,
                expiresAt
            );
        }
    }
}