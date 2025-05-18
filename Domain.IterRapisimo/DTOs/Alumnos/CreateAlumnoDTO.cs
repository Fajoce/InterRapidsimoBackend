using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs
{
    public class CreateAlumnoDTO
    {
        public int UsuarioID { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
    }
}
