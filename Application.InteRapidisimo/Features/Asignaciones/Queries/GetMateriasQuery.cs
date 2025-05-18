using Domain.IterRapisimo.DTOs.Asignaciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Asignaciones.Queries
{
    public record  GetMateriasQuery: IRequest<List<SelectMateriasDTO>>
    {
    }
}
