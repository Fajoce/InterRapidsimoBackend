using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Docentes.Commands
{
    public record CreateDocenteCommand: IRequest<bool>
    {
        public int UsuarioID { get; set; }
        public string Especialidad { get; set; }
        public DateTime? FechaIngreso { get; set; }
    }
}
