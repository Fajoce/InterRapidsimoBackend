using Application.InteRapidisimo.Features.Docentes.Commands;
using Application.InteRapidisimo.Features.Docentes.Queries;
using Domain.IterRapisimo;
using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs.Docentes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.InterRapisimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class DocentesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocentesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearDocente([FromBody] CreateDocenteCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest(Result<string>.Failure("No se pudo crear el docente"));

            return Ok(Result<string>.Success("Docente creado exitosamente"));
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAlumno([FromBody] ActualizarDocenteDTO dto)
        {
            var result = await _mediator.Send(new UpdateDocenteByIdCommand(dto));

            if (!result)
                return NotFound("No se pudo actualizar el docente. Verifica que exista.");

            return Ok(true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocente(int id)
        {
            var result = await _mediator.Send(new DeleteDocenteByIdCommand(id));

            if (!result)
                return NotFound($"No se encontró el docente con ID {id}");

            return Ok(true);
        }
        [HttpGet]
        public async Task<ActionResult<List<VerAlumnosDTO>>> GetAll()
        {
            var alumnos = await _mediator.Send(new GetDocentesQuery());

            if (alumnos == null || !alumnos.Any())
                return NotFound("No hay docentes registrados.");

            return Ok(alumnos);
        }

        [HttpGet("SelectedTeachers")]
        public async Task<ActionResult<List<SelectDocentesDTO>>> GetSelectedTeachers()
        {
            var teachers = await _mediator.Send(new GetSelectedTeachersQuery());

            if (teachers == null || !teachers.Any())
                return NotFound("No hay docentes registrados.");

            return Ok(teachers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTeacherByIdl(int id)
        {
            var alumno = await _mediator.Send(new GetDocenteByIdQuery(id));

            if (alumno == null)
                return NotFound($"No existe docente con ese id{id}");

            return Ok(alumno);
        }
    }
}
