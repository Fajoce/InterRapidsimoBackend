using Domain.IterRapisimo.DTOs.Materias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Materias.Commands
{
    public record UpdateMateriaByIdCommand: IRequest<bool>
    {
        public ActualizarMateriaDTO _subject { get; set; }

        public UpdateMateriaByIdCommand(ActualizarMateriaDTO subject)
        {
            _subject = subject;
        }
    }
}
