using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Entities
{
    public class Matricula
    {
        [Key]
        public int MatriculaID { get; set; }

        public int AlumnoID { get; set; }
        public int GradoID { get; set; }

        public int AnioLectivo { get; set; }
        public DateTime FechaMatricula { get; set; }

        public Alumno Alumno { get; set; }
        public Grado Grado { get; set; }

        public ICollection<Calificacion> Calificaciones { get; set; }
    }
}
