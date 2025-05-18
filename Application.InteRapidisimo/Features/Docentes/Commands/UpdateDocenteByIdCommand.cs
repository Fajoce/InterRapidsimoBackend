using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs.Docentes;
using Domain.IterRapisimo.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Docentes.Commands
{
    public record UpdateDocenteByIdCommand: IRequest<bool>
    {
        public ActualizarDocenteDTO _docente { get; set; }

    public UpdateDocenteByIdCommand(ActualizarDocenteDTO docente)
    {
        _docente = docente;
    }
 
    }
}
