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
    public class GetGradoByIdQueryHandler : IRequestHandler<GetGradoByIdQuery, VerGradosDTO>
    {
        private readonly IGradosRepository _repo;

        public GetGradoByIdQueryHandler(IGradosRepository repo)
        {
            _repo = repo;
        }

        public Task<VerGradosDTO> Handle(GetGradoByIdQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetCourseById(request.id);
        }
    }
}
