using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs.Grados
{
    public class VerGradosDTO
    {
        public int GradoID { get; set; }

         public string Nombre { get; set; }
        public string Nivel { get; set; }
    }
}
