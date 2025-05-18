using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Entities
{
    public class Calificacion
    {
        [Key]
        public int CalificacionID { get; set; }

        public int MatriculaID { get; set; }
        public int AsignacionID { get; set; }

        [Range(0, 100)]
        public decimal Nota { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string Observacion { get; set; }

        public Matricula Matricula { get; set; }
        public Asignacion Asignacion { get; set; }
    }
}
