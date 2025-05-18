using Domain.IterRapisimo.DTOs.Grados;
using Domain.IterRapisimo.DTOs.Matriculas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Matriculas.Commands
{
    public record  UpdateMatriculaCommand : IRequest<bool>
    {
        public ActualizarMatriculaDTO _record { get; set; }

        public UpdateMatriculaCommand(ActualizarMatriculaDTO record)
        {
            _record = record;
        }
    }
}
