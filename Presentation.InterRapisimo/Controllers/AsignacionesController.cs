using Application.InteRapidisimo.Features.Alumnos.Command;
using Application.InteRapidisimo.Features.Alumnos.Queries;
using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.InteRapidisimo.Features.Asignaciones.Commands;
using Domain.IterRapisimo.DTOs.Asignaciones;
using Application.InteRapidisimo.Features.Asignaciones.Queries;
using Microsoft.AspNetCore.Authorization;
using Domain.IterRapisimo.DTOs;

namespace Presentation.InterRapisimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AsignacionesController : BaseApiController
    {
        
        [HttpPost]
        public async Task<IActionResult> CrearAsignaciones([FromBody] CreateAsignacionesCommand command)
        {
            var result = await Mediator.Send(command);

            if (!result)
                return BadRequest(Result<string>.Failure("No se pudo crear la asignación"));

            return Ok(true);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsignaciones([FromBody] ActualizarAsignacionDTO dto)
        {
            var result = await Mediator.Send(new UpdateAsignacionesByIdCommand(dto));

            if (!result)
                return NotFound("No se pudo actualizar la asignación. Verifica que exista.");

            return Ok("la asignación fue actualizada correctamente.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAignaciono(int id)
        {
            var result = await Mediator.Send(new DeleteAsignacionesByIdCommand(id));

            if (!result)
                return NotFound($"No se encontró la asignación con ID {id}");

            return Ok("la asignación fue eliminada correctamente.");
        }
        [HttpGet]
        public async Task<ActionResult<List<VerAlumnosDTO>>> GetAll()
        {
            var alumnos = await Mediator.Send(new GetAsignacionesQuery());

            if (alumnos == null || !alumnos.Any())
                return NotFound("No hay asignaciones registradas.");

            return Ok(alumnos);
        }

        [HttpGet("Materias")]
        public async Task<ActionResult<List<SelectMateriasDTO>>> GetAllSubjects()
        {
            var materias = await Mediator.Send(new GetMateriasQuery());

            if (materias == null || !materias.Any())
                return NotFound("No hay asignaciones registradas.");

            return Ok(materias);
        }

        [HttpGet("Grados")]
        public async Task<ActionResult<List<SelectGradosDTO>>> GetAllGrades()
        {
            var grados = await Mediator.Send(new GetGradosQuery());

            if (grados == null || !grados.Any())
                return NotFound("No hay asignaciones registradas.");

            return Ok(grados);
        }

        [HttpGet("Docentes")]
        public async Task<ActionResult<List<SelectDocenteDTO>>> GetAllTeachers()
        {
            var grados = await Mediator.Send(new GetDocentesQuery());

            if (grados == null || !grados.Any())
                return NotFound("No hay asignaciones registradas.");

            return Ok(grados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAssigmentByIdl(int id)
        {
            var alumno = await Mediator.Send(new GetAsignacionesByIdQuery(id));

            if (alumno == null)
                return NotFound($"No existe la asignación con ese id{id}");

            return Ok(alumno);
        }
    }
}

