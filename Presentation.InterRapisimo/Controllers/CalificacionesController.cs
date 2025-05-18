using Application.InteRapidisimo.Features.Alumnos.Command;
using Application.InteRapidisimo.Features.Alumnos.Queries;
using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.InteRapidisimo.Features.Calificaciones.Commands;
using Domain.IterRapisimo.DTOs.Calificaciones;
using Application.InteRapidisimo.Features.Calificaciones.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.InterRapisimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CalificacionesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalificacionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCalificaciones([FromBody] CreateCalificacionCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest(Result<string>.Failure("No se pudieron crear las calificaciones"));

            return Ok(Result<string>.Success("calificaciones creadas exitosamente"));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Updatecalificaciones([FromBody] ActualizarCalificacionesDTO dto)
        {
            var result = await _mediator.Send(new UpdateCalificacionesByIdCommand(dto));

            if (!result)
                return NotFound("No se pudieron actualizar las calificaciones. Verifica que exista.");

            return Ok("Calificaciones actualizadas correctamente.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificaciones(int id)
        {
            var result = await _mediator.Send(new DeleteCalificacionesByIdCommand(id));

            if (!result)
                return NotFound($"No se encontraron las calificaciones con ID {id}");

            return Ok("Calificaciones eliminadas correctamente.");
        }
        [HttpGet]
        public async Task<ActionResult<List<VerCalificacionesDTO>>> GetAll()
        {
            var grades = await _mediator.Send(new GetCalificacionesQuery());

            if (grades == null || !grades.Any())
                return NotFound("No hay calificaciones  registradas.");

            return Ok(grades);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCalificacionesByIdl(int id)
        {
            var grade = await _mediator.Send(new GetCalificacionesByIdQuery(id));

            if (grade == null)
                return NotFound($"No existe alumno con ese id{id}");

            return Ok(grade);
        }
    }
}

