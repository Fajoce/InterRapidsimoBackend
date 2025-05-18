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
    public class GetDocenteByidQueryHandler : IRequestHandler<GetDocenteByIdQuery, VerDocentesDTO>
    {
        private readonly IDocentesRepository _repo;

        public GetDocenteByidQueryHandler(IDocentesRepository repo)
        {
            _repo = repo;
        }

        public Task<VerDocentesDTO> Handle(GetDocenteByIdQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetTeacherById(request.id);
        }
    }
}
