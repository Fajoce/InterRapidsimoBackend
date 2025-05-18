using Domain.IterRapisimo.Repositories.Calificaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Calificaciones.Commands
{
    public class UpdateCalificacionesByIdCommandHandler : IRequestHandler<UpdateCalificacionesByIdCommand, bool>
    {
        private readonly ICalificacionesRepository _repo;

        public UpdateCalificacionesByIdCommandHandler(ICalificacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(UpdateCalificacionesByIdCommand request, CancellationToken cancellationToken)
        {
            return _repo.UpdateGrades(request._dto);
        }
    }
}
