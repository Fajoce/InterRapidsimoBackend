using Domain.IterRapisimo.DTOs.Asignaciones;
using Domain.IterRapisimo.Repositories.Asignaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Asignaciones.Commands
{
    public class CreateAsignacionesCommandHandler : IRequestHandler<CreateAsignacionesCommand, bool>
    {
        private readonly IAsignacionesRepository _repo;

        public CreateAsignacionesCommandHandler(IAsignacionesRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(CreateAsignacionesCommand request, CancellationToken cancellationToken)
        {
            var assigment = new CreateAsinacionDTO
            {
                DocenteID = request.DocenteID,
                MateriaID = request.MateriaID,
                GradoID = request.GradoID
            };
            return _repo.CreateAssigment(assigment);
        }
    }
}
