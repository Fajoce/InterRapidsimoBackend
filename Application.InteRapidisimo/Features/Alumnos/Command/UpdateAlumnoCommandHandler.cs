using Domain.IterRapisimo.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Alumnos.Command
{
    public class UpdateAlumnoCommandHandler : IRequestHandler<UpdateAlumnoCommand, bool>
    {
        private readonly IAlumnosRepository _repo;

        public UpdateAlumnoCommandHandler(IAlumnosRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateAlumnoCommand request, CancellationToken cancellationToken)
        {
            return await _repo.UpdateStudent(request.Alumno);
        }
    }
}
