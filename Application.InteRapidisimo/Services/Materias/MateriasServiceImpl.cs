using Domain.IterRapisimo.DTOs.Materias;
using Domain.IterRapisimo.Entities;
using Domain.IterRapisimo.Repositories.Materias;
using InfraStrucure.InterRapidisimo.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Application.InteRapidisimo.Services.Materias
{
    public class MateriasServiceImpl : IMateriasRepository
    {
        private readonly ColegioDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MateriasServiceImpl(ColegioDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateSubjectAreas(CreateMateriasDTO subject)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userClaims = httpContext?.User;

            if (userClaims == null || !userClaims.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException("Usuario no autenticado");

            var userIdString = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdString, out var userId))
                throw new UnauthorizedAccessException("ID de usuario no válido");

            var usuario = await _context.Usuarios.FindAsync(userId);

            if (usuario == null)
                throw new UnauthorizedAccessException("Usuario no encontrado");

            if (usuario.Rol != "Administrador")
                throw new UnauthorizedAccessException("Acceso denegado. Solo administradores pueden crear matrículas.");
                
             bool materiaExiste = await _context.Materias
             .AnyAsync(m => m.Nombre.ToLower().Trim() == subject.Nombre.ToLower().Trim());

                 if (materiaExiste)
                 {
                     return false; // Ya existe una materia con ese nombre
                 }
                 var subjectAreas = new Materia
                 {
                     Nombre = subject.Nombre.Trim()
                 };
                 if (subjectAreas == null)
                 {
                     return false;
                 }

            await _context.Materias.AddAsync(subjectAreas);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteSubjectAreasById(int id)
        {
            var subject = await _context.Materias.FirstOrDefaultAsync(s => s.MateriaID == id);
            if (subject == null)
            {
                return false;
            }

            _context.Materias.Remove(subject);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<List<VerMateriasDTO>> GetAllSubjectAreas()
        {
            var list = await(from a in _context.Materias

                             select new VerMateriasDTO
                             {
                                 MateriaID = a.MateriaID,
                                 Nombre = a.Nombre
                             }).ToListAsync();

            return list;
        }

        public async Task<VerMateriasDTO> GetSubjectAreasById(int id)
        {
            var subject = await(from a in _context.Materias
                                where a.MateriaID == id
                                select new VerMateriasDTO
                                {
                                    MateriaID = a.MateriaID,
                                    Nombre = a.Nombre,

                                }).FirstOrDefaultAsync();

            return subject;
        }



        public async Task<bool> UpdateSubjectAreast(ActualizarMateriaDTO _subject)
        {
            // Buscar usuario relacionado
            var subject = await _context.Materias.FindAsync(_subject.MateriaID);
            if (subject == null)
                return false;

            subject.MateriaID = _subject.MateriaID;
            subject.Nombre = _subject.Nombre;

            _context.Materias.Update(subject);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
