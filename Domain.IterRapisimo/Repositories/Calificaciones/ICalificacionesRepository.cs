using Domain.IterRapisimo.DTOs.Calificaciones;
using Domain.IterRapisimo.DTOs.Docentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Repositories.Calificaciones
{
    public interface ICalificacionesRepository
    {
        Task<List<VerCalificacionesDTO>> GetAllGrades();
        Task<VerCalificacionesDTO> GetGradesById(int id);
        Task<bool> CreateGrades(CreateCalificacionDTO teacher);
        Task<bool> UpdateGrades(ActualizarCalificacionesDTO teacher);
        Task<bool> DeleteGradesById(int id);
    }
}
