using Domain.IterRapisimo.DTOs;
using Domain.IterRapisimo.DTOs.Usuarios;
using Domain.IterRapisimo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Repositories
{
    public interface IUsuarioRepository
    {
       // Task<Usuario> AutenticarAsync(string email, string password);
        Task<GetUsuariosDTO> GetByIdAsync(int id);
        Task<bool> CreateUsuario(CreateUsuarioDTO usuario);
    }

}
