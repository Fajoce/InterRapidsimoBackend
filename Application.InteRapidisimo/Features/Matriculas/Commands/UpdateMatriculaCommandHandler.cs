using Domain.IterRapisimo.Repositories.matriculas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Matriculas.Commands
{
    public class UpdateMatriculaCommandHandler : IRequestHandler<UpdateMatriculaCommand, bool>
    {
        private readonly IMatriculasRepository _repo;

        public UpdateMatriculaCommandHandler(IMatriculasRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(UpdateMatriculaCommand request, CancellationToken cancellationToken)
        {
            return _repo.UpdateRecord(request._record);
        }
    }
}
