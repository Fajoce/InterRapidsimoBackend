using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Docentes.Commands
{
    public record DeleteDocenteByIdCommand(int id) : IRequest<bool>
    {
    }
}
