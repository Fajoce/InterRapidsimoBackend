using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Features.Grados.Commands
{
    public class CreateGradoCommand: IRequest<bool>
    {
        public string Nombre { get; set; }
        public string Nivel { get; set; }
    }
}
