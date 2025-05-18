using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Entities
{
    public class Docente
    {
        [Key]

        public int DocenteID { get; set; }

        public int UsuarioID { get; set; }

        public string Especialidad { get; set; }
        public DateTime? FechaIngreso { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }
    }
}
