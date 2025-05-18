using Domain.IterRapisimo.DTOs.Materias;
using Domain.IterRapisimo.Repositories.Materias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Materias.Queries
{
    public class GetMateriasQueryHandler : IRequestHandler<GetMateriasQuery, List<VerMateriasDTO>>
    {
        private readonly IMateriasRepository _repo;

        public GetMateriasQueryHandler(IMateriasRepository repo)
        {
            _repo = repo;
        }

        public Task<List<VerMateriasDTO>> Handle(GetMateriasQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetAllSubjectAreas();
        }
    }
}
