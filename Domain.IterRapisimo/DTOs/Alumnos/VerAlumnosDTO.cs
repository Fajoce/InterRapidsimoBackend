using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs.Alumnos
{
    public class VerAlumnosDTO
    {
        public int AlumnoID { get; set; }
        public int UsuarioID { get; set; }
        public string AlumnoNombre { get; set; }
        public string AlumnoEmail { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int GradoID { get; set; }
        public string GradoNombre { get; set; }
    }
}
