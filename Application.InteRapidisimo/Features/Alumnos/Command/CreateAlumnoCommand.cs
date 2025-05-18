using Domain.IterRapisimo.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Alumnos.Command
{
    public class CreateAlumnoCommand: IRequest<bool>
    {
        public int UsuarioID { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
    }
}
