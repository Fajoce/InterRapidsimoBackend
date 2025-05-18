using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Matriculas.Commands
{
    public record CreateMatriculaCommand: IRequest<bool>
    {
        public int AlumnoID { get; set; }
        public int GradoID { get; set; }

        public int AnioLectivo { get; set; }
        public DateTime FechaMatricula { get; set; }
    }
}
