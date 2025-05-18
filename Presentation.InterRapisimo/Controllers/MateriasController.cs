using Application.InteRapidisimo.Features.Grados.Commands;
using Application.InteRapidisimo.Features.Grados.Queries;
using Domain.IterRapisimo.DTOs.Grados;
using Domain.IterRapisimo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.InteRapidisimo.Features.Materias.Commands;
using Domain.IterRapisimo.DTOs.Materias;
using Application.InteRapidisimo.Features.Materias.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.InterRapisimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class MateriasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MateriasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearMaterias([FromBody] CreateMateriaCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest(false);

            return Ok(true);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMateria([FromBody] ActualizarMateriaDTO dto)
        {
            var result = await _mediator.Send(new UpdateMateriaByIdCommand(dto));

            if (!result)
                return NotFound("No se pudo actualizar la asignatura. Verifica que exista.");

            return Ok(true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateria(int id)
        {
            var result = await _mediator.Send(new DeleteMateriaByIdCommand(id));

            if (!result)
                return NotFound($"No se encontró la asignatura con ID {id}");

            return Ok(true);
        }
        [HttpGet]
        public async Task<ActionResult<List<VerMateriasDTO>>> GetAll()
        {
            var alumnos = await _mediator.Send(new GetMateriasQuery());

            if (alumnos == null || !alumnos.Any())
                return NotFound("No hay asignaturas registradas.");

            return Ok(alumnos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMateriaByIdl(int id)
        {
            var alumno = await _mediator.Send(new GetMateriasByIdQuery(id));

            if (alumno == null)
                return NotFound($"No existe asignatura con ese id{id}");

            return Ok(alumno);
        }
    }
}

