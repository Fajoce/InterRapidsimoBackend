using Domain.IterRapisimo.DTOs;
using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.Entities;
using Domain.IterRapisimo.Repositories;
using InfraStrucure.InterRapidisimo.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace Application.InteRapidisimo.Services
{
    public class AlumnosServiceImpl : IAlumnosRepository
    {
        private readonly ColegioDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AlumnosServiceImpl(ColegioDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateStudent(CreateAlumnoDTO alumno)
        {
            await isAuthAndAdmAsync();

            var student = new Alumno
            {
                UsuarioID = alumno.UsuarioID,
                Direccion = alumno.Direccion,
                FechaNacimiento = alumno.FechaNacimiento
            };
            if(student == null)
            {
                return false;
            }

           await _context.Alumnos.AddAsync(student);
            _context.SaveChanges();
            return true;

        }

        public async Task<bool> DeleteStudentById(int id)
        {
            await isAuthAndAdmAsync();
            var student = await _context.Alumnos.FirstOrDefaultAsync(s => s.AlumnoID == id);
            if (student == null)
            {
                return false;
            }

            _context.Alumnos.Remove(student);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<VerAlumnosDTO>> GetAllStudents()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userClaims = httpContext?.User;

            if (userClaims == null || !userClaims.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException("Usuario no autenticado");

            var userIdClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var usuarioId))
                throw new UnauthorizedAccessException("ID de usuario no válido");

            var usuario = await _context.Usuarios.FindAsync(usuarioId);
            if (usuario == null)
                throw new UnauthorizedAccessException("Usuario no encontrado");

            if (usuario.Rol == "Administrador")
            {
                // Mostrar todos los alumnos con su grado
                return await (from a in _context.Alumnos
                              join u in _context.Usuarios on a.UsuarioID equals u.UsuarioID
                              join m in _context.Matriculas on a.AlumnoID equals m.AlumnoID
                              join g in _context.Grados on m.GradoID equals g.GradoID
                              select new VerAlumnosDTO
                              {
                                  AlumnoID = a.AlumnoID,
                                  UsuarioID = u.UsuarioID,
                                  AlumnoNombre = u.Nombre,
                                  AlumnoEmail = u.Email,
                                  FechaNacimiento = a.FechaNacimiento,
                                  Direccion = a.Direccion,
                                  GradoID = g.GradoID,
                                  GradoNombre = g.Nombre
                              }).ToListAsync();
            }
            else if (usuario.Rol == "Alumno")
            {
                // Obtener ID del alumno
                var alumno = await _context.Alumnos.FirstOrDefaultAsync(a => a.UsuarioID == usuario.UsuarioID);
                if (alumno == null)
                    throw new UnauthorizedAccessException("Alumno no encontrado");

                // Obtener matrícula del alumno para saber su grado
                var matricula = await _context.Matriculas.FirstOrDefaultAsync(m => m.AlumnoID == alumno.AlumnoID);
                if (matricula == null)
                    throw new UnauthorizedAccessException("Matrícula no encontrada");

                var gradoId = matricula.GradoID;

                // Mostrar alumnos del mismo grado
                return await (from a in _context.Alumnos
                              join u in _context.Usuarios on a.UsuarioID equals u.UsuarioID
                              join m in _context.Matriculas on a.AlumnoID equals m.AlumnoID
                              join g in _context.Grados on m.GradoID equals g.GradoID
                              where g.GradoID == gradoId
                              select new VerAlumnosDTO
                              {
                                  AlumnoID = a.AlumnoID,
                                  UsuarioID = u.UsuarioID,
                                  AlumnoNombre = u.Nombre,
                                  AlumnoEmail = u.Email,
                                  FechaNacimiento = a.FechaNacimiento,
                                  Direccion = a.Direccion,
                                  GradoID = g.GradoID,
                                  GradoNombre = g.Nombre
                              }).ToListAsync();
            }

            // Otros roles (opcionalmente lanza error o retorna vacío)
            throw new UnauthorizedAccessException("Acceso no permitido");
        }

        public async Task<VerAlumnosDTO> GetStudentById(int id)

        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userClaims = httpContext?.User;

            if (userClaims == null || !userClaims.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException("Usuario no autenticado");

            var userIdClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var usuarioId))
                throw new UnauthorizedAccessException("ID de usuario no válido");
  
            var student = await (from a in _context.Alumnos
                                        join u in _context.Usuarios on a.UsuarioID equals u.UsuarioID
                                        join m in _context.Matriculas on a.AlumnoID equals m.AlumnoID
                                        join g in _context.Grados on m.GradoID equals g.GradoID
                                      

                                        select new VerAlumnosDTO
                                        {
                                            AlumnoID = a.AlumnoID,
                                            UsuarioID = u.UsuarioID,
                                            AlumnoNombre = u.Nombre,
                                            AlumnoEmail = u.Email,
                                            FechaNacimiento = a.FechaNacimiento,
                                            Direccion = a.Direccion,
                                            GradoID = g.GradoID,
                                            GradoNombre = g.Nombre
                                        }).FirstOrDefaultAsync();

            return student;
        }

        public async Task<bool> UpdateStudent(ActualizarAlumnoDTO alumno)
        {
            // Buscar usuario relacionado
            var usuario = await _context.Usuarios.FindAsync(alumno.UsuarioID);
            if (usuario == null)
                return false;

            // Buscar alumno relacionado al usuario
            var alumnoEntity = await _context.Alumnos
                .FirstOrDefaultAsync(a => a.UsuarioID == alumno.UsuarioID);

            if (alumnoEntity == null)
                return false;

            // Actualizar propiedades del usuario
            usuario.Nombre = alumno.Nombre;
            usuario.Email = alumno.Email;

            // Actualizar propiedades del alumno
            alumnoEntity.FechaNacimiento = alumno.FechaNacimiento;
            alumnoEntity.Direccion = alumno.Direccion;

            _context.Usuarios.Update(usuario);
            _context.Alumnos.Update(alumnoEntity);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetAlumnosDTO>> getAllUsers()
        {
            var users = await(from u in _context.Usuarios
                              where u.Rol == "Alumno"
                              select new GetAlumnosDTO
                              {
                                  UsuarioID = u.UsuarioID,
                                  Nombre = u.Nombre
                              }).ToListAsync();
            return users;
        }

        private async Task<bool> isAuthAndAdmAsync()
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
            return true;
        }

    }
}
