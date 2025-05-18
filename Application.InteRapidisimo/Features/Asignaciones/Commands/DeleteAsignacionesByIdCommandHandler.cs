using Domain.IterRapisimo.Repositories.Asignaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Asignaciones.Commands
{
    public class DeleteAsignacionesByIdCommandHandler : IRequestHandler<DeleteAsignacionesByIdCommand, bool>
    {
        private readonly IAsignacionesRepository _repo;

        public DeleteAsignacionesByIdCommandHandler(IAsignacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(DeleteAsignacionesByIdCommand request, CancellationToken cancellationToken)
        {
            return _repo.DeleteAssigmentById(request.id);
        }
    }
}
