using Application.InteRapidisimo.Services;
using Application.InteRapidisimo.Services.Usuarios;
using Domain.IterRapisimo.DTOs;
using Domain.IterRapisimo.Entities;
using Domain.IterRapisimo.Repositories;
using InfraStrucure.InterRapidisimo.DataContext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Usuarios.Command
{
   public  class CreateUsuarioCommandHandler: IRequestHandler<CreateUsuarioCommand, bool>
    {
        private readonly IUsuarioRepository _repo;

        public CreateUsuarioCommandHandler(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new CreateUsuarioDTO
                {
                    Nombre = request.Nombre,
                    Email = request.Email,
                    PasswordHash = request.PasswordHash,
                    Rol = request.Rol
                };
                await _repo.CreateUsuario(user);

                return true;
            }
            catch (Exception)
            {
                // Aquí puedes usar ILogger para loguear el error
                return false;
            }
        }
    }
}
