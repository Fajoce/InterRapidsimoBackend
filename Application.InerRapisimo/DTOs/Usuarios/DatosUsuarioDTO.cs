using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InerRapisimo.DTOs.Usuarios
{
    public class DatosUsuarioDTO
    {
        public int UsuarioID { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public string PasswordHash { get; set; } = string.Empty;

        public string Rol { get; set; } = string.Empty;

    }
}
