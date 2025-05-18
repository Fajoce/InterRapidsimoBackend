using Domain.IterRapisimo.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Alumnos.Command
{
    public  class DeleteAlumnoByIdCommandHandler : IRequestHandler<DeleteAlumnoByIdCommand, bool>
    {
        private readonly IAlumnosRepository _repo;

        public DeleteAlumnoByIdCommandHandler(IAlumnosRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo)); 
        }

        public async Task<bool> Handle(DeleteAlumnoByIdCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteStudentById(request.id);           
            
        }
    }
}
