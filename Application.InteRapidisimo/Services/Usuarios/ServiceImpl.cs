using Domain.IterRapisimo.DTOs;
using Domain.IterRapisimo.DTOs.Usuarios;
using Domain.IterRapisimo.Entities;
using Domain.IterRapisimo.Repositories;
using InfraStrucure.InterRapidisimo.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Application.InteRapidisimo.Services
{
    public class ServiceImpl : IUsuarioRepository
    {
        private readonly ColegioDbContext _context;

        public ServiceImpl(ColegioDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUsuario(CreateUsuarioDTO usuario)
        {
            try
            {
                var user = new Usuario
                {
                    
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    PasswordHash = usuario.PasswordHash,
                    Rol = usuario.Rol
              
                };

                _context.Usuarios.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public async Task<GetUsuariosDTO> GetByIdAsync(int id)
        {
            var user = (from u in _context.Usuarios
                        where u.UsuarioID == id
                        select new GetUsuariosDTO
                        {
                            UsuarioID = u.UsuarioID,
                            Nombre = u.Nombre,
                            Email = u.Email,
                            PasswordHash = u.PasswordHash,
                            Rol = u.Rol
                        }).FirstOrDefaultAsync();
            return await user;
        }
    }
}
