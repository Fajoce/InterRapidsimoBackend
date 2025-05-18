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
    public class GetMatriculaByIdQueryHandler : IRequestHandler<GetMatriculaByidQuery, VerMatriculasDTO>
    {
        private readonly IMatriculasRepository _repo;

        public GetMatriculaByIdQueryHandler(IMatriculasRepository repo)
        {
            _repo = repo;
        }

        public Task<VerMatriculasDTO> Handle(GetMatriculaByidQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetRecordById(request.id);
        }
    }
}
