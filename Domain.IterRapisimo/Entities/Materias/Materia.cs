using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Entities
{
    public class Materia
    {
        [Key]
        public int MateriaID { get; set; }

        public string Nombre { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }
    }
}
