using Domain.IterRapisimo.DTOs.Usuarios;
using Domain.IterRapisimo.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Usuarios.Queries
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, GetUsuariosDTO>
    {
        private readonly IUsuarioRepository _repo;

        public GetUsuarioByIdQueryHandler(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public Task<GetUsuariosDTO> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _repo.GetByIdAsync(request.id);
            return user;
        }
    }
}
