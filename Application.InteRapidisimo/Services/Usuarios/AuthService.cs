using Domain.IterRapisimo.DTOs.Usuarios;
using Domain.IterRapisimo.Interfaces;
using InfraStrucure.InterRapidisimo.DataContext;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.InteRapidisimo.Services.Usuarios
{
    public class AuthService : IAuthService
    {
        private readonly ColegioDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ColegioDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginRequestDTO loginDto)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Email == loginDto.Email);

            if (user == null || user.PasswordHash != loginDto.Password) 
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UsuarioID.ToString()),
            new Claim("given_name", user.Nombre),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Rol)
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
