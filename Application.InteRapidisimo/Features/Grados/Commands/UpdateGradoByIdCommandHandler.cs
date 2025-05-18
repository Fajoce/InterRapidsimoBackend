using Domain.IterRapisimo.Repositories.Grados;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Grados.Commands
{
    public class UpdateGradoByIdCommandHandler : IRequestHandler<UpdateGradoByIdCommand, bool>
    {
        private readonly IGradosRepository _repo;

        public UpdateGradoByIdCommandHandler(IGradosRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(UpdateGradoByIdCommand request, CancellationToken cancellationToken)
        {
            return _repo.UpdateCourse(request._grado);
        }
    }
}
