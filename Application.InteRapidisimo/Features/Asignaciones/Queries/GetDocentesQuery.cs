using Domain.IterRapisimo.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Asignaciones.Queries
{
    public record GetDocentesQuery: IRequest<List<SelectDocenteDTO>>
    {
    }
}
