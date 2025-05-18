using Domain.IterRapisimo.DTOs;
using Domain.IterRapisimo.Entities;
using Domain.IterRapisimo.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Alumnos.Command
{
    public class CreateAlumnoCommandHandler : IRequestHandler<CreateAlumnoCommand, bool>
    {
        private readonly IAlumnosRepository _repo;

        public CreateAlumnoCommandHandler(IAlumnosRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CreateAlumnoCommand request, CancellationToken cancellationToken)
        {
            var student = new CreateAlumnoDTO
            {
                UsuarioID = request.UsuarioID,
                FechaNacimiento = request.FechaNacimiento,
                Direccion = request.Direccion
            };

            await _repo.CreateStudent(student);
            return true;
        }
    }
}
