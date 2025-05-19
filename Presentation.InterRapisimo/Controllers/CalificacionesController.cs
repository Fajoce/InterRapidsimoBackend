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
  
    public class CalificacionesController : BaseApiController
    {
       
        [HttpPost]
        public async Task<IActionResult> CrearCalificaciones([FromBody] CreateCalificacionCommand command)
        {
            var result = await Mediator.Send(command);

            if (!result)
                return BadRequest(Result<string>.Failure("No se pudieron crear las calificaciones"));

            return Ok(Result<string>.Success("calificaciones creadas exitosamente"));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Updatecalificaciones([FromBody] ActualizarCalificacionesDTO dto)
        {
            var result = await Mediator.Send(new UpdateCalificacionesByIdCommand(dto));

            if (!result)
                return NotFound("No se pudieron actualizar las calificaciones. Verifica que exista.");

            return Ok("Calificaciones actualizadas correctamente.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificaciones(int id)
        {
            var result = await Mediator.Send(new DeleteCalificacionesByIdCommand(id));

            if (!result)
                return NotFound($"No se encontraron las calificaciones con ID {id}");

            return Ok("Calificaciones eliminadas correctamente.");
        }
        [HttpGet]
        public async Task<ActionResult<List<VerCalificacionesDTO>>> GetAll()
        {
            var grades = await Mediator.Send(new GetCalificacionesQuery());

            if (grades == null || !grades.Any())
                return NotFound("No hay calificaciones  registradas.");

            return Ok(grades);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCalificacionesByIdl(int id)
        {
            var grade = await Mediator.Send(new GetCalificacionesByIdQuery(id));

            if (grade == null)
                return NotFound($"No existe alumno con ese id{id}");

            return Ok(grade);
        }
    }
}

