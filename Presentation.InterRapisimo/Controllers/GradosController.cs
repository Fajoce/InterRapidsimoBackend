using Application.InteRapidisimo.Features.Alumnos.Command;
using Application.InteRapidisimo.Features.Alumnos.Queries;
using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.InteRapidisimo.Features.Grados.Commands;
using Domain.IterRapisimo.DTOs.Grados;
using Application.InteRapidisimo.Features.Grados.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.InterRapisimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class GradosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GradosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearGrado([FromBody] CreateGradoCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest(Result<string>.Failure("No se pudo crear el grado"));

            return Ok(Result<string>.Success("Grado creado exitosamente"));
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateGrado([FromBody] ActualizarGradoDTO dto)
        {
            var result = await _mediator.Send(new UpdateGradoByIdCommand(dto));

            if (!result)
                return NotFound("No se pudo actualizar el grado. Verifica que exista.");

            return Ok(true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrado(int id)
        {
            var result = await _mediator.Send(new DeleteGradoByIdCommand(id));

            if (!result)
                return NotFound($"No se encontró el grado con ID {id}");

            return Ok("Grado eliminado correctamente.");
        }
        [HttpGet]
        public async Task<ActionResult<List<VerGradosDTO>>> GetAll()
        {
            var alumnos = await _mediator.Send(new GetgradosQuery());

            if (alumnos == null || !alumnos.Any())
                return NotFound("No hay alumnos registrados.");

            return Ok(alumnos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGradoByIdl(int id)
        {
            var alumno = await _mediator.Send(new GetGradoByIdQuery(id));

            if (alumno == null)
                return NotFound($"No existe grado con ese id{id}");

            return Ok(alumno);
        }
    }
}

