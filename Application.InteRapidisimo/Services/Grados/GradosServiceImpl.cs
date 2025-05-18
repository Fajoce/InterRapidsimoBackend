using Domain.IterRapisimo.DTOs.Grados;
using Domain.IterRapisimo.Entities;
using Domain.IterRapisimo.Repositories.Grados;
using InfraStrucure.InterRapidisimo.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Application.InteRapidisimo.Services.Grados
{
    public class GradosServiceImpl : IGradosRepository
    {
        private readonly ColegioDbContext _context;

        public GradosServiceImpl(ColegioDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCourse(CrearGradosDTO grados)
        {
            var course = new Grado
            {
                Nombre = grados.Nombre,
                Nivel = grados.Nivel
            };
            if (course == null)
            {
                return false;
            }

            await _context.Grados.AddAsync(course);
            _context.SaveChanges();
            return true;

        }

        public async Task<bool> DeleteCourseById(int id)
        {
            var course = await _context.Grados.FirstOrDefaultAsync(s => s.GradoID == id);
            if (course == null)
            {
                return false;
            }

            _context.Grados.Remove(course);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<VerGradosDTO>> GetAllCourses()
        {
            var list = await(from a in _context.Grados
                         
                             select new VerGradosDTO
                             {
                                 GradoID = a.GradoID,
                                 Nombre = a.Nombre,
                                 Nivel = a.Nivel
                             }).ToListAsync();

            return list;
        }

        public async Task<VerGradosDTO> GetCourseById(int id)
        {
            var course = await(from a in _context.Grados
                               where a.GradoID == id
                             select new VerGradosDTO
                             {
                                 GradoID = a.GradoID,
                                 Nombre = a.Nombre,
                                 Nivel = a.Nivel
                             }).FirstOrDefaultAsync();

            return course;
        }

        public async Task<bool> UpdateCourse(ActualizarGradoDTO grado)
        {
            var course = await _context.Grados.FindAsync(grado.GradoID);
            if (course == null)
                return false;

            course.Nombre = grado.Nombre;
            course.Nivel = grado.Nivel;

            _context.Grados.Update(course);
            _context.SaveChanges();
            return true;
        }
    }
}
