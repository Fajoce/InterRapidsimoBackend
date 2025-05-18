using Domain.IterRapisimo.DTOs;
using Domain.IterRapisimo.DTOs.Asignaciones;
using Domain.IterRapisimo.DTOs.Docentes;
using Domain.IterRapisimo.Entities;
using Domain.IterRapisimo.Repositories.Asignaciones;
using InfraStrucure.InterRapidisimo.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.Services.Asignaciones
{
    public class AsignacionesServiceImpl : IAsignacionesRepository
    {
        private readonly ColegioDbContext _context;

        public AsignacionesServiceImpl(ColegioDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAssigment(CreateAsinacionDTO assigment)
        {
            var assig = new Asignacion
            {
             
                DocenteID = assigment.DocenteID,
                MateriaID = assigment.MateriaID,
                GradoID = assigment.GradoID
            };
            if (assig == null)
            {
                return false;
            }

            await _context.Asignaciones.AddAsync(assig);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAssigmentById(int id)
        {
            var assigment = await _context.Asignaciones.FirstOrDefaultAsync(s => s.AsignacionID == id);
            if (assigment == null)
            {
                return false;
            }

            _context.Asignaciones.Remove(assigment);
            await _context.SaveChangesAsync();

            return true;
        }

        public  async Task<List<VerAsignacionesDTO>> GetAllAssigments()
        {
            var list = await(from a in _context.Asignaciones
                             join d in _context.Docentes
                             on a.DocenteID equals d.DocenteID
                             join m in _context.Materias
                             on a.MateriaID equals m.MateriaID
                             join g in _context.Grados
                             on a.GradoID equals g.GradoID
                             join u in _context.Usuarios
                             on d.UsuarioID equals u.UsuarioID

                             select new VerAsignacionesDTO
                             {
                                 
                                 AsignacionID = a.AsignacionID,
                                 DocenteID = d.DocenteID,
                                 NombreDocente = u.Nombre,
                                 MateriaID = m.MateriaID,
                                 NombreMateria = m.Nombre,
                                 GradoID = a.GradoID,
                                 NombreGrado = g.Nombre
                           
                             }).ToListAsync();

            return list;
        }

        public async Task<VerAsignacionesDTO> GetAssigmentById(int id)
        {
            var assigment = await(from a in _context.Asignaciones
                             join d in _context.Docentes
                             on a.DocenteID equals d.DocenteID
                             join m in _context.Materias
                             on a.MateriaID equals m.MateriaID
                             join g in _context.Grados
                             on a.GradoID equals g.GradoID
                             join u in _context.Usuarios
                             on d.UsuarioID equals u.UsuarioID
                             where a.AsignacionID == id

                             select new VerAsignacionesDTO
                             {
                                 AsignacionID = a.AsignacionID,
                                 DocenteID = d.DocenteID,
                                 NombreDocente = u.Nombre,
                                 MateriaID = m.MateriaID,
                                 NombreMateria = m.Nombre,
                                 GradoID = a.GradoID,
                                 NombreGrado = g.Nombre

                             }).FirstOrDefaultAsync();

            return assigment;
        }

        public async Task<List<SelectDocenteDTO>> SelectDocentesDTO()
        {
            var list = await (from d in _context.Docentes
                             join u in _context.Usuarios on d.UsuarioID equals u.UsuarioID
                             where u.Rol == "Docente"
                             select new SelectDocenteDTO {
                                 DocenteID = d.DocenteID,
                                 Nombre = u.Nombre
                             })
                             .Distinct()
                             .ToListAsync();
            return list;
        }

        public async Task<List<SelectGradosDTO>> SelectGradosDTO()
        {
            var list = await(from g in _context.Grados
                             select new SelectGradosDTO
                             {
                                 GradoID = g.GradoID,
                                 Nombre = g.Nombre
                             }).ToListAsync();
            return list;
        }

        public async Task<List<SelectMateriasDTO>> SelectMateriasDTO()
        {
            var list = await (from m in _context.Materias
                              select new SelectMateriasDTO
                              {
                                  MateriaID = m.MateriaID,
                                  Nombre = m.Nombre
                              }).ToListAsync();
            return list;

        }

        public async Task<bool> UpdateAssigment(ActualizarAsignacionDTO assigment)
        {
            var assig = await _context.Asignaciones.FindAsync(assigment.AsignacionID);
            if (assig == null)
                return false;

            assig.DocenteID = assigment.DocenteID;
            assig.MateriaID = assigment.MateriaID;
            assig.GradoID = assigment.GradoID;

            _context.Asignaciones.Update(assig);
            _context.SaveChanges();
            return true;
        }
    }
}
