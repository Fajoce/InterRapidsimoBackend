using Domain.IterRapisimo.DTOs.Matriculas;
using Domain.IterRapisimo.Repositories.matriculas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Matriculas.Queries
{
    public class GetSelectAlumnosQueryHandler : IRequestHandler<GetSelectAlumnosQuery, List<SelectAlumnosDTO>>
    {
        private readonly IMatriculasRepository _repo;

        public GetSelectAlumnosQueryHandler(IMatriculasRepository repo)
        {
            _repo = repo;
        }

        public Task<List<SelectAlumnosDTO>> Handle(GetSelectAlumnosQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetAllStudents();
        }
    }
}
