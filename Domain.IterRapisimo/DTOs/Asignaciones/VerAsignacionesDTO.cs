using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs.Asignaciones
{
    public class VerAsignacionesDTO
    {
        public int AsignacionID { get; set; }
        public string NombreDocente { get; set; } = string.Empty;
        public int DocenteID { get; set; }
        public string NombreMateria { get; set; } = string.Empty;
        public int MateriaID { get; set; }
        public string NombreGrado { get; set; } = string.Empty;
        public int GradoID { get; set; }
    }
}
