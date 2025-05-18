using Domain.IterRapisimo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InfraStrucure.InterRapidisimo.DataContext
{
    public class ColegioDbContext : DbContext
    {
        public ColegioDbContext(DbContextOptions<ColegioDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relaciones 1 a 1
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Alumno)
                .WithOne(a => a.Usuario)
                .HasForeignKey<Alumno>(a => a.UsuarioID);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Docente)
                .WithOne(d => d.Usuario)
                .HasForeignKey<Docente>(d => d.UsuarioID);

        }
    }
}


