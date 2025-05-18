using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs.Asignaciones
{
    public class ActualizarAsignacionDTO
    {
        public int AsignacionID { get; set; }
        public int DocenteID { get; set; }
        public int MateriaID { get; set; }
        public int GradoID { get; set; }
    }
}
