using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Calificaciones.Commands
{
    public record CreateCalificacionCommand: IRequest<bool>
    {
        public int MatriculaID { get; set; }
        public int AsignacionID { get; set; }
        public decimal Nota { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string Observacion { get; set; }
    }
}
