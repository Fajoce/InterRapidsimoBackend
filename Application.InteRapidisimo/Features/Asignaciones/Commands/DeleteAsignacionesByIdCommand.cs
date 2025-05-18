using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Asignaciones.Commands
{
    public record DeleteAsignacionesByIdCommand(int id): IRequest<bool>
    {
    }
}
