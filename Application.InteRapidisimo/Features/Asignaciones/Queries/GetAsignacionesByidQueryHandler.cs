using Domain.IterRapisimo.DTOs.Asignaciones;
using Domain.IterRapisimo.Repositories.Asignaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Asignaciones.Queries
{
    public class GetAsignacionesByidQueryHandler : IRequestHandler<GetAsignacionesByIdQuery, VerAsignacionesDTO>
    {
        private readonly IAsignacionesRepository _repo;

        public GetAsignacionesByidQueryHandler(IAsignacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<VerAsignacionesDTO> Handle(GetAsignacionesByIdQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetAssigmentById(request.id);
        }
    }
}
