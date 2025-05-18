using Domain.IterRapisimo.DTOs.Materias;
using Domain.IterRapisimo.DTOs.Matriculas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Materias.Queries
{
    public record GetMateriasByIdQuery(int id): IRequest<VerMateriasDTO>
    {
    }
}
