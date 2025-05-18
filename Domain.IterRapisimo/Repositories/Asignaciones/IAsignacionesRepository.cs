using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IterRapisimo.DTOs.Asignaciones;
using Domain.IterRapisimo.DTOs.Docentes;

namespace Domain.IterRapisimo.Repositories.Asignaciones
{
    public interface IAsignacionesRepository
    {
        Task<List<VerAsignacionesDTO>> GetAllAssigments();
        Task<VerAsignacionesDTO> GetAssigmentById(int id);
        Task<bool> CreateAssigment(CreateAsinacionDTO  assigment);
        Task<bool> UpdateAssigment(ActualizarAsignacionDTO alumno);
        Task<bool> DeleteAssigmentById(int id);
        Task<List<SelectGradosDTO>> SelectGradosDTO();
        Task<List<SelectDocenteDTO>> SelectDocentesDTO();
        Task<List<SelectMateriasDTO>> SelectMateriasDTO();

    }
}
