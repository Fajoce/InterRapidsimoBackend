using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Materias.Commands
{
    public record CreateMateriaCommand: IRequest<bool>
    {
        public string Nombre { get; set; }
    }
}
