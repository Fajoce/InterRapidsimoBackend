using Domain.IterRapisimo.DTOs.Calificaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Calificaciones.Commands
{
    public record UpdateCalificacionesByIdCommand: IRequest<bool>
    {
        public ActualizarCalificacionesDTO _dto { get; set; }
        public UpdateCalificacionesByIdCommand(ActualizarCalificacionesDTO dto)
        {
            _dto = dto;
            
        }
    }
}
