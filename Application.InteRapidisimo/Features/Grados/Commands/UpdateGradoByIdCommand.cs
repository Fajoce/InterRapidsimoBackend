using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs.Grados;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Grados.Commands
{
    public record UpdateGradoByIdCommand : IRequest<bool>
    {
        public ActualizarGradoDTO _grado { get; set; }

        public UpdateGradoByIdCommand(ActualizarGradoDTO grado)
        {
            _grado = grado;
        }
    }
}
 
