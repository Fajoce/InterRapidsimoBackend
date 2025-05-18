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
    public class GetmatriculasQueryHandler : IRequestHandler<GetMatriculasQuery, List<VerMatriculasDTO>>
    {
        private readonly IMatriculasRepository _repo;

        public GetmatriculasQueryHandler(IMatriculasRepository repo)
        {
            _repo = repo;
        }

        public Task<List<VerMatriculasDTO>> Handle(GetMatriculasQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetAllRecords();
        }
    }
}
