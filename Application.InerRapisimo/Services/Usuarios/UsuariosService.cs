using Application.InerRapisimo.DTOs.Usuarios;
using Application.InerRapisimo.Repositories;
using Domain.IterRapisimo.Entities;
using Domain.IterRapisimo.Repositories;
using InfraEstructura.InterRapisimo.DataContext;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.InerRapisimo.Services.Usuarios
{
    public class UsuariosService : IUsuarioRepository
    {
        private readonly IUsuariosService _repo;
        private readonly IConfiguration _config;

        public UsuariosService(IUsuariosService repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public Task<Usuario> AutenticarAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<(string Token, int UsuarioEmail, string UsuarioPassword)> AutenticarJwtAsync(UsuarioLoginDTO loginDto)
        {
            var usuario = await _repo.AutenticarAsync(loginDto.Email, loginDto.PasswordHash);
            if (usuario == null) return (null, 0);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, paciente.Id.ToString()),
                new Claim(ClaimTypes.Name, paciente.Nombres)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (tokenHandler.WriteToken(token), paciente.Id);
        }
        }

        public Task<bool> CreatePaciente(CreateUsuarioDTO paciente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateUsuario(Usuario paciente)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CreateUsuarioDTO> VerMisDatos(int id)
        {
            throw new NotImplementedException();
        }
    }
}
