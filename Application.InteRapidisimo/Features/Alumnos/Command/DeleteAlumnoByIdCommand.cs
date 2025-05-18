using MediatR;

namespace Application.InteRapidisimo.Features.Alumnos.Command
{
    public record DeleteAlumnoByIdCommand(int id): IRequest<bool>
    {
    }
}
