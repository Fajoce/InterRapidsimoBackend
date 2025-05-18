using Domain.IterRapisimo.DTOs.Calificaciones;
using Domain.IterRapisimo.Repositories.Calificaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Calificaciones.Commands
{
    public class CreateCalificacionesCommandHandler : IRequestHandler<CreateCalificacionCommand, bool>
    {
        private readonly ICalificacionesRepository _repo;

        public CreateCalificacionesCommandHandler(ICalificacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(CreateCalificacionCommand request, CancellationToken cancellationToken)
        {
            var grade = new CreateCalificacionDTO
            {
                MatriculaID = request.MatriculaID,
                AsignacionID = request.AsignacionID,
                Nota = request.Nota,
                FechaRegistro = request.FechaRegistro,
                Observacion = request.Observacion
            };

            return _repo.CreateGrades(grade);
        }
    }
}
