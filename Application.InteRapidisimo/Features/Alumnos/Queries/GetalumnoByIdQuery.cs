using Domain.IterRapisimo.DTOs.Alumnos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Alumnos.Queries
{
    public record GetalumnoByIdQuery(int id) : IRequest<VerAlumnosDTO>
    {
    }
}
