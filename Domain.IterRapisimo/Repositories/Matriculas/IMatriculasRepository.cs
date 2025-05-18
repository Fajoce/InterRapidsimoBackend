using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IterRapisimo.DTOs.Matriculas;

namespace Domain.IterRapisimo.Repositories.matriculas
{
    public interface IMatriculasRepository
    {
        Task<List<VerMatriculasDTO>> GetAllRecords();
        Task<List<SelectAlumnosDTO>> GetAllStudents();
        Task<VerMatriculasDTO> GetRecordById(int id);
        Task<bool> CreateRecord(CreateMatriculaDTO matricula);
        Task<bool> UpdateRecord(ActualizarMatriculaDTO alumno);
        Task<bool> DeleteRecordById(int id);
    }
}
