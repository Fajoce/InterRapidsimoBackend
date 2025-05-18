using Domain.IterRapisimo.DTOs.Calificaciones;
using Domain.IterRapisimo.Repositories.Calificaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Calificaciones.Queries
{
    public class GetcalificacionesByIdQueryHandler : IRequestHandler<GetCalificacionesByIdQuery, VerCalificacionesDTO>
    {
        private readonly ICalificacionesRepository _repo;

        public GetcalificacionesByIdQueryHandler(ICalificacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<VerCalificacionesDTO> Handle(GetCalificacionesByIdQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetGradesById(request.id);
        }
    }
}
