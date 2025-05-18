using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs.Calificaciones
{
    public class ActualizarCalificacionesDTO
    {
        public int CalificacionID { get; set; }
        public int MatriculaID { get; set; }
        public int AsignacionID { get; set; }
        public decimal Nota { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string Observacion { get; set; }
}
}
