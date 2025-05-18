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
    public class GetcalificacionesqueryHandler : IRequestHandler<GetCalificacionesQuery, List<VerCalificacionesDTO>>
    {
        private readonly ICalificacionesRepository _repo;

        public GetcalificacionesqueryHandler(ICalificacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<List<VerCalificacionesDTO>> Handle(GetCalificacionesQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetAllGrades();
        }
    }
}
