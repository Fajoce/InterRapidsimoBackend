using Domain.IterRapisimo.DTOs;
using Domain.IterRapisimo.DTOs.Docentes;
using Domain.IterRapisimo.Repositories.Asignaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Asignaciones.Queries
{
    public class GetDocentesQueryHandler : IRequestHandler<GetDocentesQuery, List<SelectDocenteDTO>>
    {
        private readonly IAsignacionesRepository _repo;

        public GetDocentesQueryHandler(IAsignacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<List<SelectDocenteDTO>> Handle(GetDocentesQuery request, CancellationToken cancellationToken)
        {
            return _repo.SelectDocentesDTO();
        }
    }
}
