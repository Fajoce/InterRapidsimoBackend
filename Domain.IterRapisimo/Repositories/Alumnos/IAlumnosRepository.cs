using Domain.IterRapisimo.DTOs;
using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Repositories
{
    public interface IAlumnosRepository
    {
        Task<List<VerAlumnosDTO>> GetAllStudents();
        Task<VerAlumnosDTO> GetStudentById(int id);
        Task<bool> CreateStudent(CreateAlumnoDTO alumno);
        Task<bool> UpdateStudent (ActualizarAlumnoDTO alumno);
        Task<bool> DeleteStudentById(int id);
        Task<List<GetAlumnosDTO>> getAllUsers();
    }
}
