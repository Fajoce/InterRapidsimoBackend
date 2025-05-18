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
    public class GetMateriasQueryHandler : IRequestHandler<GetMateriasQuery, List<SelectMateriasDTO>>
    {
        private readonly IAsignacionesRepository _repo;

        public GetMateriasQueryHandler(IAsignacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<List<SelectMateriasDTO>> Handle(GetMateriasQuery request, CancellationToken cancellationToken)
        {
            return _repo.SelectMateriasDTO();
        }
    }
}
