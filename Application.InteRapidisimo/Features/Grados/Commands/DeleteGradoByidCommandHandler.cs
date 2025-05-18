using Domain.IterRapisimo.Repositories.Grados;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Grados.Commands
{
    public class DeleteGradoByidCommandHandler : IRequestHandler<DeleteGradoByIdCommand, bool>
    {
        private readonly IGradosRepository _repo;

        public DeleteGradoByidCommandHandler(IGradosRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(DeleteGradoByIdCommand request, CancellationToken cancellationToken)
        {
            return _repo.DeleteCourseById(request.id);
        }
    }
}
