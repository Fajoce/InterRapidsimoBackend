using Domain.IterRapisimo.DTOs.Asignaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Asignaciones.Commands
{
    public record UpdateAsignacionesByIdCommand: IRequest<bool>
    {
        public ActualizarAsignacionDTO _dto { get; set; }

        public UpdateAsignacionesByIdCommand(ActualizarAsignacionDTO dto)
        {
            _dto = dto;
            
        }
    }
}
