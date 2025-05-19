using Application.InteRapidisimo.Features.Alumnos.Command;
using Application.InteRapidisimo.Features.Alumnos.Queries;
using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.InteRapidisimo.Features.Matriculas.Commands;
using Domain.IterRapisimo.DTOs.Matriculas;
using Application.InteRapidisimo.Features.Matriculas.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.InterRapisimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class MatriculasController : BaseApiController
    {

        [HttpPost]
        public async Task<IActionResult> CrearMatricula([FromBody] CreateMatriculaCommand command)
        {
            var result = await Mediator.Send(command);

            if (!result)
                return BadRequest(Result<string>.Failure("No se pudo crear la Matricula"));

            return Ok(true);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMatricula([FromBody] ActualizarMatriculaDTO dto)
        {
            var result = await Mediator.Send(new UpdateMatriculaCommand(dto));

            if (!result)
                return NotFound("No se pudo actualizar la amtricula. Verifica que exista.");

            return Ok("Matricula actualizado correctamente.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatricula(int id)
        {
            var result = await Mediator.Send(new DeleteMatriculaCommand(id));

            if (!result)
                return NotFound($"No se encontró la matricula con ID {id}");

            return Ok("Matricula eliminado correctamente.");
        }
        [HttpGet]
        public async Task<ActionResult<List<VerMatriculasDTO>>> GetAll()
        {
            var alumnos = await Mediator.Send(new GetMatriculasQuery());

            if (alumnos == null || !alumnos.Any())
                return NotFound("No hay matriculas registrados.");

            return Ok(alumnos);
        }

        [HttpGet("Alumnos")]
        public async Task<ActionResult<List<SelectAlumnosDTO>>> GetAllStudents()
        {
            var alumnos = await Mediator.Send(new GetSelectAlumnosQuery());

            if (alumnos == null || !alumnos.Any())
                return NotFound("No hay alumnos registrados.");

            return Ok(alumnos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRecordByIdl(int id)
        {
            var alumno = await Mediator.Send(new GetMatriculaByidQuery(id));

            if (alumno == null)
                return NotFound($"No existe alumno con ese id{id}");

            return Ok(alumno);
        }
    }
}

