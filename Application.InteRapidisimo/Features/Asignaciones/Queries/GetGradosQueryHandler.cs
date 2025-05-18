using Domain.IterRapisimo.DTOs.Asignaciones;
using Domain.IterRapisimo.Repositories.Asignaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Asignaciones.Queries
{
    public class GetGradosQueryHandler : IRequestHandler<GetGradosQuery, List<SelectGradosDTO>>
    {
        private readonly IAsignacionesRepository _repo;

        public GetGradosQueryHandler(IAsignacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<List<SelectGradosDTO>> Handle(GetGradosQuery request, CancellationToken cancellationToken)
        {
            return _repo.SelectGradosDTO();
        }
    }
}
