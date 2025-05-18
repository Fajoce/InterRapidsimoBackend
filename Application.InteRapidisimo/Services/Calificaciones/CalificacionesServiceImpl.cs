using Domain.IterRapisimo.DTOs.Calificaciones;
using Domain.IterRapisimo.Entities;
using Domain.IterRapisimo.Repositories.Calificaciones;
using InfraStrucure.InterRapidisimo.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Application.InteRapidisimo.Services.Calificaciones
{
    public class CalificacionesServiceImpl : ICalificacionesRepository
    {
        private readonly ColegioDbContext _context;

        public CalificacionesServiceImpl(ColegioDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateGrades(CreateCalificacionDTO _grades)
        {
            var grades = new Calificacion
            {

              MatriculaID = _grades.MatriculaID,
              AsignacionID = _grades.AsignacionID,
              Nota = _grades.Nota,
              FechaRegistro = _grades.FechaRegistro,
              Observacion = _grades.Observacion
            };
            if (grades == null)
            {
                return false;
            }

            await _context.Calificaciones.AddAsync(grades);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteGradesById(int id)
        {
            var garde = await _context.Calificaciones.FirstOrDefaultAsync(s => s.CalificacionID == id);
            if (garde == null)
            {
                return false;
            }

            _context.Calificaciones.Remove(garde);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<VerCalificacionesDTO>> GetAllGrades()
        {
            var list = await(from c in _context.Calificaciones
                             join m in _context.Matriculas
                             on c.MatriculaID equals m.MatriculaID
                             join a in _context.Asignaciones
                             on c.AsignacionID equals a.AsignacionID                            
 
                             select new VerCalificacionesDTO
                             {
                                 AsignacionID = a.AsignacionID,
                                 MatriculaID = c.MatriculaID,
                                 CalificacionID = c.CalificacionID,
                                 Nota = c.Nota,
                                 FechaRegistro = c.FechaRegistro,
                                 Observacion = c.Observacion
                              }).ToListAsync();

            return list;
        }

        public async Task<VerCalificacionesDTO> GetGradesById(int id)
        {
            var grade = await(from c in _context.Calificaciones
                             join m in _context.Matriculas
                             on c.MatriculaID equals m.MatriculaID
                             join a in _context.Asignaciones
                             on c.AsignacionID equals a.AsignacionID
                             where c.AsignacionID == id
                             select new VerCalificacionesDTO
                             {
                                 AsignacionID = a.AsignacionID,
                                 MatriculaID = c.MatriculaID,
                                 CalificacionID = c.CalificacionID,
                                 Nota = c.Nota,
                                 FechaRegistro = c.FechaRegistro,
                                 Observacion = c.Observacion
                             }).FirstOrDefaultAsync();

            return grade;
        }

        public async Task<bool> UpdateGrades(ActualizarCalificacionesDTO grade)
        {
            var grades = await _context.Calificaciones.FindAsync(grade.CalificacionID);
            if (grades == null)
                return false;

            grades.AsignacionID = grade.AsignacionID;
            grades.CalificacionID = grade.CalificacionID;
            grades.Nota = grade.Nota;
            grades.FechaRegistro = grade.FechaRegistro;
            grades.Observacion = grade.Observacion;

            _context.Calificaciones.Update(grades);
            _context.SaveChanges();
            return true;
        }
    }
}
