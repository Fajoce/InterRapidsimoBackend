using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Entities
{
    public class Asignacion
    {
        [Key]
        public int AsignacionID { get; set; }

        public int DocenteID { get; set; }
        public int MateriaID { get; set; }
        public int GradoID { get; set; }

        public Docente Docente { get; set; }
        public Materia Materia { get; set; }
        public Grado Grado { get; set; }

        public ICollection<Calificacion> Calificaciones { get; set; }

    }
}
