using Domain.IterRapisimo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Entities
{
    public class Alumno
    {
        [Key]
        public int AlumnoID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public Usuario Usuario { get; set; }

    }
}
