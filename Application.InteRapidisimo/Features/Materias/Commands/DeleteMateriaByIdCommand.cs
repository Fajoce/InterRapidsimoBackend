using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Materias.Commands
{
    public record DeleteMateriaByIdCommand(int id): IRequest<bool>
    {
    }
}
