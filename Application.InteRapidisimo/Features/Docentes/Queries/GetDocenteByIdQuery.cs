using Domain.IterRapisimo.DTOs.Docentes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Docentes.Queries
{
    public record GetDocenteByIdQuery(int id): IRequest<VerDocentesDTO>
    {
    }
}
