using Domain.IterRapisimo.Repositories.matriculas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Matriculas.Commands
{
    public class DeleteMatriculaCommandHandler : IRequestHandler<DeleteMatriculaCommand, bool>
    {
        private readonly IMatriculasRepository _repo;

        public DeleteMatriculaCommandHandler(IMatriculasRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(DeleteMatriculaCommand request, CancellationToken cancellationToken)
        {
            return _repo.DeleteRecordById(request.id);
        }
    }
}
