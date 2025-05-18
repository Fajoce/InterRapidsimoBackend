using Domain.IterRapisimo.DTOs.Docentes;
using Domain.IterRapisimo.DTOs.Grados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Repositories.Docentes
{
    public interface IDocentesRepository
    {
        Task<List<VerDocentesDTO>> GetAllTeachers();
        Task<List<SelectDocentesDTO>> GetSelectedTeachers();
        Task<VerDocentesDTO> GetTeacherById(int id);
        Task<bool> CreateTeacher(CrearDocenteDTO  teacher);
        Task<bool> UpdateTeacher(ActualizarDocenteDTO teacher);
        Task<bool> DeleteDocenteByyId(int id);
    }
}
