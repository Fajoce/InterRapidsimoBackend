using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Asignaciones.Commands
{
    public class CreateAsignacionesCommand: IRequest<bool>
    {
        public int DocenteID { get; set; }
        public int MateriaID { get; set; }
        public int GradoID { get; set; }
    }
}
