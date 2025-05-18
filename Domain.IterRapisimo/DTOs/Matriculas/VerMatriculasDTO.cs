using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs.Matriculas
{
    public class VerMatriculasDTO
    {
        public int MatriculaID { get; set; }
        public int AlumnoID { get; set; }
        public string NombreAlumno { get; set; }
        public int GradoID { get; set; }
        public string GradoAlumno { get; set; }
        public int AnioLectivo { get; set; }
        public DateTime FechaMatricula { get; set; }
    }
}
