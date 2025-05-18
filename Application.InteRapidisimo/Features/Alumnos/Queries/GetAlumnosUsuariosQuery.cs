using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Alumnos.Queries
{
    public record GetAlumnosUsuariosQuery: IRequest<List<GetAlumnosDTO>>
    {
    }
}
