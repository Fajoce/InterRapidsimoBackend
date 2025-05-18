using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Matriculas.Commands
{
    public record DeleteMatriculaCommand(int id): IRequest<bool>
    {
    }
}
