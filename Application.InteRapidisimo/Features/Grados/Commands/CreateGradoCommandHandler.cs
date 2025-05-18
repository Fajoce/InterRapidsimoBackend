using Domain.IterRapisimo.DTOs.Grados;
using Domain.IterRapisimo.Repositories.Grados;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Grados.Commands
{
    public class CreateGradoCommandHandler : IRequestHandler<CreateGradoCommand, bool>
    {
        private readonly IGradosRepository _repo;

        public CreateGradoCommandHandler(IGradosRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(CreateGradoCommand request, CancellationToken cancellationToken)
        {
            var course = new CrearGradosDTO
            {
                Nombre = request.Nombre,
                Nivel = request.Nivel

            };
            return _repo.CreateCourse(course);
        }
    }
}
