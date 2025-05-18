using Domain.IterRapisimo.Repositories.Materias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Materias.Commands
{
    public class DeleteMateriaByIdCommandHandler : IRequestHandler<DeleteMateriaByIdCommand, bool>
    {
        private readonly IMateriasRepository _repo;

        public DeleteMateriaByIdCommandHandler(IMateriasRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(DeleteMateriaByIdCommand request, CancellationToken cancellationToken)
        {
            return _repo.DeleteSubjectAreasById(request.id);
        }
    }
}
