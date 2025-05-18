using Domain.IterRapisimo.Repositories.Docentes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Docentes.Commands
{
    public class UpdateDocenteByIdCommandHandler : IRequestHandler<UpdateDocenteByIdCommand, bool>
    {
        private readonly IDocentesRepository _repo;

        public UpdateDocenteByIdCommandHandler(IDocentesRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(UpdateDocenteByIdCommand request, CancellationToken cancellationToken)
        {
            return _repo.UpdateTeacher(request._docente);
        }
    }
}
