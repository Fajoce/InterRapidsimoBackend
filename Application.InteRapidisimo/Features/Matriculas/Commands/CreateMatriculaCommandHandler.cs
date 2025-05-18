using Domain.IterRapisimo.DTOs.Grados;
using Domain.IterRapisimo.DTOs.Matriculas;
using Domain.IterRapisimo.Repositories.matriculas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Matriculas.Commands
{
    public class CreateMatriculaCommandHandler : IRequestHandler<CreateMatriculaCommand, bool>
    {
        private readonly IMatriculasRepository _repo;

        public CreateMatriculaCommandHandler(IMatriculasRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(CreateMatriculaCommand request, CancellationToken cancellationToken)
        {
            var record = new CreateMatriculaDTO
            {
               AlumnoID = request.AlumnoID,
               GradoID = request.GradoID,
               FechaMatricula = request.FechaMatricula,
               AnioLectivo = request.AnioLectivo

            };
            return _repo.CreateRecord(record);
        }
    }
}
