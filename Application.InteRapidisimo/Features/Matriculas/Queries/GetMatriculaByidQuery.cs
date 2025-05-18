using Domain.IterRapisimo.DTOs.Matriculas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Matriculas.Queries
{
    public record GetMatriculaByidQuery(int id): IRequest<VerMatriculasDTO>
    {
    }
}
