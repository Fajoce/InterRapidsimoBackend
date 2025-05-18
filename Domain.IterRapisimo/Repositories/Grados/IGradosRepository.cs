using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IterRapisimo.DTOs.Grados;

namespace Domain.IterRapisimo.Repositories.Grados
{
    public interface IGradosRepository
    {
        Task<List<VerGradosDTO>> GetAllCourses();
        Task<VerGradosDTO> GetCourseById(int id);
        Task<bool> CreateCourse(CrearGradosDTO grados);
        Task<bool> UpdateCourse(ActualizarGradoDTO grado);
        Task<bool> DeleteCourseById(int id);
    }
}
