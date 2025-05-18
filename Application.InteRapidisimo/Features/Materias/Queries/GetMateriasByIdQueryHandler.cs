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
    public class GetMateriasByIdQueryHandler : IRequestHandler<GetMateriasByIdQuery, VerMateriasDTO>
    {
        private readonly IMateriasRepository _repo;

        public GetMateriasByIdQueryHandler(IMateriasRepository repo)
        {
            _repo = repo;
        }

        public Task<VerMateriasDTO> Handle(GetMateriasByIdQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetSubjectAreasById(request.id);
        }
    }
}
