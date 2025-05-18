using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.DTOs.Materias
{
    public class CreateMateriasDTO
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MinLength(10, ErrorMessage = "El campo Nombre debe tener al menos 10 caracteres.")]
        public string Nombre { get; set; } = string.Empty;
    }
}
