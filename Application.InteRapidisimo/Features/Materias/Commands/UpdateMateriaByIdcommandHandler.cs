using Domain.IterRapisimo.Repositories.Materias;
using MediatR;

namespace Application.InteRapidisimo.Features.Materias.Commands
{
    public class UpdateMateriaByIdcommandHandler : IRequestHandler<UpdateMateriaByIdCommand, bool>
    {
        private readonly IMateriasRepository _repo;

        public UpdateMateriaByIdcommandHandler(IMateriasRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(UpdateMateriaByIdCommand request, CancellationToken cancellationToken)
        {
            return _repo.UpdateSubjectAreast(request._subject);
        }
    }
}
