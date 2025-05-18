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
    public class GetAlumnosQueryHandler : IRequestHandler<GetAlumnoQuery, List<VerAlumnosDTO>>
    {
        private readonly IAlumnosRepository _repo;

        public GetAlumnosQueryHandler(IAlumnosRepository repo)
        {
            _repo = repo;
        }

        public Task<List<VerAlumnosDTO>> Handle(GetAlumnoQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetAllStudents();
        }
    }
}
