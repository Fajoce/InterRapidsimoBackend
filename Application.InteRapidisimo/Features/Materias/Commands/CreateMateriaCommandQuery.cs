using Domain.IterRapisimo.DTOs.Materias;
using Domain.IterRapisimo.Repositories.Materias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Materias.Commands
{
    public class CreateMateriaCommandQuery : IRequestHandler<CreateMateriaCommand, bool>
    {
        private readonly IMateriasRepository _repo;

        public CreateMateriaCommandQuery(IMateriasRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(CreateMateriaCommand request, CancellationToken cancellationToken)
        {
            var subject = new CreateMateriasDTO
            {
                Nombre = request.Nombre
            };

            return _repo.CreateSubjectAreas(subject);
        }
    }
}
