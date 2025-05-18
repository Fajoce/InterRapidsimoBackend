using Domain.IterRapisimo.DTOs.Grados;
using Domain.IterRapisimo.Repositories.Grados;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Grados.Queries
{
    public class GetGradoQueryHandler : IRequestHandler<GetgradosQuery, List<VerGradosDTO>>
    {
        private readonly IGradosRepository _repo;

        public GetGradoQueryHandler(IGradosRepository repo)
        {
            _repo = repo;
        }

        public Task<List<VerGradosDTO>> Handle(GetgradosQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetAllCourses();
        }
    }
}
