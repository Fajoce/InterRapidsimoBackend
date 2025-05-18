using Application.InteRapidisimo.Features.Alumnos.Command;
using Application.InteRapidisimo.Features.Alumnos.Queries;
using Domain.IterRapisimo;
using Domain.IterRapisimo.DTOs.Alumnos;
using Domain.IterRapisimo.DTOs.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.InterRapisimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlumnosController : BaseApiController
    {
       
        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] CreateAlumnoCommand command)
        {
            var result = await Mediator.Send(command);

            if (!result)
                return BadRequest(Result<string>.Failure("No se pudo crear el usuario"));

            return Ok(Result<string>.Success("Usuario creado exitosamente"));
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAlumno([FromBody] ActualizarAlumnoDTO dto)
        {
            var result = await Mediator.Send(new UpdateAlumnoCommand(dto));

            if (!result)
                return NotFound("No se pudo actualizar el alumno. Verifica que exista.");

            return Ok(true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumno(int id)
        {
            var result = await Mediator.Send(new DeleteAlumnoByIdCommand(id));

            if (!result)
                return NotFound($"No se encontró el alumno con ID {id}");

            return Ok(true);
        }
        [HttpGet]
        public async Task<ActionResult<List<VerAlumnosDTO>>> GetAll()
        {
            var alumnos = await Mediator.Send(new GetAlumnoQuery());

            if (alumnos == null || !alumnos.Any())
                return NotFound("No hay alumnos registrados.");

            return Ok(alumnos);
        }
        [HttpGet("Usuarios")]
        public async Task<ActionResult<List<GetUsuariosDTO>>> GetAllUsers()
        {
            var alumnos = await Mediator.Send(new GetAlumnosUsuariosQuery());

            if (alumnos == null || !alumnos.Any())
                return NotFound("No hay usuarios registrados.");

            return Ok(alumnos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudentByIdl(int id)
        {
            var alumno = await Mediator.Send(new GetalumnoByIdQuery(id));

            if (alumno == null)
                return NotFound($"No existe alumno con ese id{id}");

            return Ok(alumno);
        }
    }
}
