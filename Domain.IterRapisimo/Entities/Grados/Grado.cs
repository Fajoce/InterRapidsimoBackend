using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Entities
{
    public class Grado
    {
        [Key]
        public int GradoID { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Nivel { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }
        public ICollection<Matricula> Matriculas { get; set; }
    }
}
