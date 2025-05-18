using Domain.IterRapisimo.DTOs.Docentes;
using Domain.IterRapisimo.Entities;
using Domain.IterRapisimo.Repositories.Docentes;
using InfraStrucure.InterRapidisimo.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Application.InteRapidisimo.Services.Docentes
{
    public class DocentesServiceImpl : IDocentesRepository
    {
        private readonly ColegioDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DocentesServiceImpl(ColegioDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> CreateTeacher(CrearDocenteDTO teacher)
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
                throw new UnauthorizedAccessException("Acceso denegado. Solo administradores pueden crear docentes.");

            var master = new Docente
            {
                UsuarioID = teacher.UsuarioID,
                Especialidad = teacher.Especialidad,
                FechaIngreso = teacher.FechaIngreso
            };
            if (master == null)
            {
                return false;
            }

            await _context.Docentes.AddAsync(master);
            _context.SaveChanges();
            return true;
        }
        

        public async Task<bool> DeleteDocenteByyId(int id)
        {
            var teacher = await _context.Docentes.FirstOrDefaultAsync(s => s.DocenteID == id);
            if (teacher == null)
            {
                return false;
            }

            _context.Docentes.Remove(teacher);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<VerDocentesDTO>> GetAllTeachers()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userClaims = httpContext?.User;

            if (userClaims == null || !userClaims.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException("Usuario no autenticado");

            var userIdClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out var usuarioId))
                throw new UnauthorizedAccessException("ID de usuario no válido");

         
            var list = await(from d in _context.Docentes
                             join u in _context.Usuarios
                             on d.UsuarioID equals u.UsuarioID
                             where u.Rol == "Docente"
                            
                             select new VerDocentesDTO
                             {
                               DocenteID = d.DocenteID,
                               UsuarioID = d.UsuarioID,
                               NombreDocente = u.Nombre,
                               Especialidad = d.Especialidad,
                               FechaIngreso = d.FechaIngreso
                             }).ToListAsync();

            return list;
        }

        public async Task<VerDocentesDTO> GetTeacherById(int id)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userClaims = httpContext?.User;

            if (userClaims == null || !userClaims.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException("Usuario no autenticado");

            var userIdClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var usuarioId))
                throw new UnauthorizedAccessException("ID de usuario no válido");
            // Obtener el AlumnoID del usuario actual
           
            var teacher = await(from d in _context.Docentes
                             join u in _context.Usuarios
                             on d.UsuarioID equals u.UsuarioID
                             where d.DocenteID == id

                             select new VerDocentesDTO
                             {
                                 DocenteID = d.DocenteID,
                                 UsuarioID = d.UsuarioID,
                                 NombreDocente = u.Nombre,
                                 Especialidad = d.Especialidad,
                                 FechaIngreso = d.FechaIngreso
                             }).FirstOrDefaultAsync();

            return teacher;
        }

        public async Task<List<SelectDocentesDTO>> GetSelectedTeachers()
        {
            var list = await (from u in _context.Usuarios                       
                       where u.Rol == "Docente"
                       select new SelectDocentesDTO
                       {
                           DocenteID = u.UsuarioID,
                           Nombre = u.Nombre
                       }).ToListAsync();
            return list;
        }

        public async Task<bool> UpdateTeacher(ActualizarDocenteDTO teacher)
        {
            var master = await _context.Docentes.FindAsync(teacher.DocenteID);
            if (master == null)
                return false;

            master.UsuarioID = teacher.UsuarioID;
            master.Especialidad = teacher.Especialidad;
            master.FechaIngreso = teacher.FechaIngreso;

            _context.Docentes.Update(master);
            _context.SaveChanges();
            return true;
        }
    }
}
