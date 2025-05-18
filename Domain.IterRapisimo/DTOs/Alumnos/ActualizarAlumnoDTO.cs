using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs.Alumnos
{
    public class ActualizarAlumnoDTO
    {
        public int UsuarioID { get; set; }           // ID del usuario relacionado
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
    }
}
