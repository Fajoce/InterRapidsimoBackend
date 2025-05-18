using Domain.IterRapisimo.DTOs.Grados;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Grados.Queries
{
    public record GetGradoByIdQuery(int id): IRequest<VerGradosDTO>
    {
    }
}
