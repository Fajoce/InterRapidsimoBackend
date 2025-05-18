using Domain.IterRapisimo.DTOs.Materias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Materias.Queries
{
    public record GetMateriasQuery: IRequest<List<VerMateriasDTO>>
    {
    }
}
