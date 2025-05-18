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
    public class GetAsignacionesQueryHandler : IRequestHandler<GetAsignacionesQuery, List<VerAsignacionesDTO>>
    {
        private readonly IAsignacionesRepository _repo;

        public GetAsignacionesQueryHandler(IAsignacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<List<VerAsignacionesDTO>> Handle(GetAsignacionesQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetAllAssigments();
        }
    }
}
