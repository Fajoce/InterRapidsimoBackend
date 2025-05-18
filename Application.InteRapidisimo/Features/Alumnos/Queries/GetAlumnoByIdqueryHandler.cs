using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Alumnos.Queries
{
    public class GetAlumnoByIdqueryHandler : IRequestHandler<GetalumnoByIdQuery, VerAlumnosDTO>
    {
        public readonly IAlumnosRepository _repo;

        public GetAlumnoByIdqueryHandler(IAlumnosRepository repo)
        {
            _repo = repo;
        }

        public async Task<VerAlumnosDTO> Handle(GetalumnoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetStudentById(request.id);
        }
    }
}
