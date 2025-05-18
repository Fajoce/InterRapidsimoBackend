using Domain.IterRapisimo.DTOs.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Usuarios.Queries
{
    public record GetUsuarioByIdQuery(int id): IRequest<GetUsuariosDTO>
    {
    }
}
