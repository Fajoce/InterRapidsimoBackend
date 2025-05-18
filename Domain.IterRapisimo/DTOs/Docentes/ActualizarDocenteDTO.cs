using Domain.IterRapisimo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs.Docentes
{
    public class ActualizarDocenteDTO
    {
        public int DocenteID { get; set; }
        public int UsuarioID { get; set; }
        public string Especialidad { get; set; }
        public DateTime? FechaIngreso { get; set; }
    }
}
