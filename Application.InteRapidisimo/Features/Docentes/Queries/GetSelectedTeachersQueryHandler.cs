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
    public class GetSelectedTeachersQueryHandler : IRequestHandler<GetSelectedTeachersQuery, List<SelectDocentesDTO>>
    {
        private readonly IDocentesRepository _repo;

        public GetSelectedTeachersQueryHandler(IDocentesRepository repo)
        {
            _repo = repo;
        }

        public Task<List<SelectDocentesDTO>> Handle(GetSelectedTeachersQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetSelectedTeachers();
        }
    }
}
