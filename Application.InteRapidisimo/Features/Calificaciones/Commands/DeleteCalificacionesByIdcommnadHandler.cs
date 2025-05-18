using Domain.IterRapisimo.Repositories.Calificaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Calificaciones.Commands
{
    public class DeleteCalificacionesByIdcommnadHandler : IRequestHandler<DeleteCalificacionesByIdCommand, bool>
    {
        private readonly ICalificacionesRepository _repo;

        public DeleteCalificacionesByIdcommnadHandler(ICalificacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(DeleteCalificacionesByIdCommand request, CancellationToken cancellationToken)
        {
            return _repo.DeleteGradesById(request.id);
        }
    }
}
