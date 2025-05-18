using Domain.IterRapisimo.Repositories.Asignaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Asignaciones.Commands
{
    public class UpdateAsignacionesByIdCommandHandler : IRequestHandler<UpdateAsignacionesByIdCommand, bool>
    {
        private readonly IAsignacionesRepository _repo;

        public UpdateAsignacionesByIdCommandHandler(IAsignacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(UpdateAsignacionesByIdCommand request, CancellationToken cancellationToken)
        {
            return _repo.UpdateAssigment(request._dto);
        }
    }
}
