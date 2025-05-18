using Domain.IterRapisimo.DTOs;
using Domain.IterRapisimo.DTOs.Alumnos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Alumnos.Command
{
    public class UpdateAlumnoCommand: IRequest<bool>
    {
        public ActualizarAlumnoDTO Alumno { get; set; }

        public UpdateAlumnoCommand(ActualizarAlumnoDTO alumno)
        {
            Alumno = alumno;
        }
    }
}
