using Domain.IterRapisimo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs.Calificaciones
{
    public class CreateCalificacionDTO
    {
        public int MatriculaID { get; set; }
        public int AsignacionID { get; set; }
        public decimal Nota { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string Observacion { get; set; }
      
    }
}
