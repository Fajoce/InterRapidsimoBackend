using Domain.IterRapisimo.DTOs;
using Domain.IterRapisimo.DTOs.Docentes;
using Domain.IterRapisimo.Repositories.Docentes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Docentes.Commands
{
    public class CreateDocenteCommandHandler : IRequestHandler<CreateDocenteCommand, bool>
    {
        private readonly IDocentesRepository _repo;

        public CreateDocenteCommandHandler(IDocentesRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CreateDocenteCommand request, CancellationToken cancellationToken)
        {
            var teacher = new CrearDocenteDTO
            {
                UsuarioID = request.UsuarioID,
                Especialidad = request.Especialidad,
                FechaIngreso = request.FechaIngreso
            };

            await _repo.CreateTeacher(teacher);
            return true;
        }
    }
}
