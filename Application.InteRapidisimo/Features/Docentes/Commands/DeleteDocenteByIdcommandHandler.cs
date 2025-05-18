using Domain.IterRapisimo.Repositories.Docentes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Docentes.Commands
{
    public class DeleteDocenteByIdcommandHandler : IRequestHandler<DeleteDocenteByIdCommand, bool>
    {
        private readonly IDocentesRepository _repo;

        public DeleteDocenteByIdcommandHandler(IDocentesRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(DeleteDocenteByIdCommand request, CancellationToken cancellationToken)
        {
            return _repo.DeleteDocenteByyId(request.id);
        }
    }
}
