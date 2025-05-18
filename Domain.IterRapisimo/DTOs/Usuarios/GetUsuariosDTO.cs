using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs.Usuarios
{
    public class GetUsuariosDTO
    {
        public int UsuarioID { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

         public string Rol { get; set; }
    }
}
