using Domain.IterRapisimo.DTOs.Docentes;
using Domain.IterRapisimo.Repositories.Docentes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Docentes.Queries
{
    public class GetDocentesQueryHandler : IRequestHandler<GetDocentesQuery, List<VerDocentesDTO>>
    {
        private readonly IDocentesRepository _repo;

        public GetDocentesQueryHandler(IDocentesRepository repo)
        {
            _repo = repo;
        }

        public Task<List<VerDocentesDTO>> Handle(GetDocentesQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetAllTeachers();
        }
    }
}
