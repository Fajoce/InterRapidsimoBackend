using Application.InteRapidisimo.Services;
using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs.Usuarios;
using Domain.IterRapisimo.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Alumnos.Queries
{
    public class GetAlumnosUsuariosQueryHandler : IRequestHandler<GetAlumnosUsuariosQuery, List<GetAlumnosDTO>>
    {
        private readonly IAlumnosRepository _repo;

        public GetAlumnosUsuariosQueryHandler(IAlumnosRepository repo)
        {
            _repo = repo;
        }

        public Task<List<GetAlumnosDTO>> Handle(GetAlumnosUsuariosQuery request, CancellationToken cancellationToken)
        {
            return _repo.getAllUsers();
        }
    }
}
