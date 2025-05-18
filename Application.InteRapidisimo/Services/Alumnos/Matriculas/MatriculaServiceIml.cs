using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs.Matriculas;
using Domain.IterRapisimo.Entities;
using Domain.IterRapisimo.Repositories.matriculas;
using InfraStrucure.InterRapidisimo.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Application.InteRapidisimo.Services.Alumnos.Matriculas
{
    public class MatriculaServiceIml : IMatriculasRepository
    {
        private readonly ColegioDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MatriculaServiceIml(ColegioDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> CreateRecord(CreateMatriculaDTO matricula)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null || !httpContext.User.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("Usuario no autenticado.");
            }

            var user = httpContext.User;

            // Verificar el rol
            var isAdmin = user.IsInRole("Administrador");

            if (!isAdmin)
            {
                throw new UnauthorizedAccessException("Acceso denegado. Solo administradores pueden crear matrículas.");
            }


            var record = new Matricula
            {
                AlumnoID = matricula.AlumnoID,
                GradoID = matricula.GradoID,
                AnioLectivo = matricula.AnioLectivo,
                FechaMatricula = matricula.FechaMatricula
            };
            if (record == null)
            {
                return false;
            }

            await _context.Matriculas.AddAsync(record);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteRecordById(int id)
        {
            var record = await _context.Matriculas.FirstOrDefaultAsync(s => s.AlumnoID == id);
            if (record == null)
            {
                return false;
            }

            _context.Matriculas.Remove(record);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<VerMatriculasDTO>> GetAllRecords()
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
                var todos = await (from m in _context.Matriculas
                                   join a in _context.Alumnos on m.AlumnoID equals a.AlumnoID
                                   join g in _context.Grados on m.GradoID equals g.GradoID
                                   join u in _context.Usuarios on a.UsuarioID equals u.UsuarioID
                                   select new VerMatriculasDTO
                                   {
                                       MatriculaID = m.MatriculaID,
                                       AlumnoID = a.AlumnoID,
                                       NombreAlumno = u.Nombre,
                                       GradoID = g.GradoID,
                                       GradoAlumno = g.Nombre,
                                       AnioLectivo = m.AnioLectivo,
                                       FechaMatricula = m.FechaMatricula
                                   }).ToListAsync();

                return todos;
            }
            else
            {
                var alumno = await _context.Alumnos.FirstOrDefaultAsync(a => a.UsuarioID == usuario.UsuarioID);
                if (alumno == null)
                    throw new UnauthorizedAccessException("El usuario no tiene un alumno asociado.");

                // Buscar la matrícula activa del alumno
                var miMatricula = await _context.Matriculas.FirstOrDefaultAsync(m => m.AlumnoID == alumno.AlumnoID);
                if (miMatricula == null)
                    throw new UnauthorizedAccessException("El alumno no tiene matrícula registrada.");

                var gradoId = miMatricula.GradoID;

                var matriculaUsuario = await (from m in _context.Matriculas
                                              join a in _context.Alumnos on m.AlumnoID equals a.AlumnoID
                                              join g in _context.Grados on m.GradoID equals g.GradoID
                                              join u in _context.Usuarios on a.UsuarioID equals u.UsuarioID
                                              where m.GradoID == gradoId
                                              select new VerMatriculasDTO
                                              {
                                                  MatriculaID = m.MatriculaID,
                                                  AlumnoID = a.AlumnoID,
                                                  NombreAlumno = u.Nombre,
                                                  GradoID = g.GradoID,
                                                  GradoAlumno = g.Nombre,
                                                  AnioLectivo = m.AnioLectivo,
                                                  FechaMatricula = m.FechaMatricula
                                              }).ToListAsync();

                return matriculaUsuario;
            }
        }

        public async Task<List<SelectAlumnosDTO>> GetAllStudents()
        {
            var students = await (from a in _context.Alumnos
                                  join u in _context.Usuarios
                           on a.UsuarioID equals u.UsuarioID
                                  where u.Rol == "Alumno"
                                  select new SelectAlumnosDTO
                                  {
                                      AlumnoID = a.AlumnoID,
                                      Nombre = u.Nombre
                                  }).ToListAsync();
            return students;
        }

        public async Task<VerMatriculasDTO> GetRecordById(int id)
        {
            var record = await(from m in _context.Matriculas
                             join a in _context.Alumnos
                                 on m.AlumnoID equals a.AlumnoID
                             join g in _context.Grados
                             on m.GradoID equals g.GradoID
                             join u in _context.Usuarios
                             on m.AlumnoID equals u.Alumno.AlumnoID
                             where m.MatriculaID == id
                             select new VerMatriculasDTO
                             {
                                 MatriculaID = m.MatriculaID,
                                 AlumnoID = a.AlumnoID,
                                 NombreAlumno = u.Nombre,
                                 GradoID = m.GradoID,
                                 GradoAlumno = g.Nombre,
                                 AnioLectivo = m.AnioLectivo,
                                 FechaMatricula = m.FechaMatricula
                             }).FirstOrDefaultAsync();

            return record;
        }

        public async Task<bool> UpdateRecord(ActualizarMatriculaDTO matricula)
        {
            var record = await _context.Matriculas.FindAsync(matricula.MatriculaID);
            if (record == null)
                return false;

            record.AlumnoID = matricula.AlumnoID;
            record.GradoID = matricula.GradoID;
            record.AnioLectivo = matricula.AnioLectivo;
            record.FechaMatricula = matricula.FechaMatricula;

            _context.Matriculas.Update(record);
            await _context.SaveChangesAsync();
            return true;
        }

       
        }
    }

