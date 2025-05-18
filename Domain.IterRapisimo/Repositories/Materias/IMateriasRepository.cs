using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IterRapisimo.DTOs.Matriculas;
using Domain.IterRapisimo.DTOs.Materias;

namespace Domain.IterRapisimo.Repositories.Materias
{
    public interface IMateriasRepository
    {
        Task<List<VerMateriasDTO>> GetAllSubjectAreas();
        Task<VerMateriasDTO> GetSubjectAreasById(int id);
        Task<bool> CreateSubjectAreas(CreateMateriasDTO alumno);
        Task<bool> UpdateSubjectAreast(ActualizarMateriaDTO alumno);
        Task<bool> DeleteSubjectAreasById(int id);
    }
}
