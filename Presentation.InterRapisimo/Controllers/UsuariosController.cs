using Application.InteRapidisimo.Features.Usuarios.Command;
using Application.InteRapidisimo.Features.Usuarios.Queries;
using Domain.IterRapisimo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.InterRapisimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] CreateUsuarioCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest(Result<string>.Failure("No se pudo crear el usuario"));

            return Ok(Result<string>.Success("Usuario creado exitosamente"));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> VerUsuarioPorId(int id)
        {
            var result = await _mediator.Send(new GetUsuarioByIdQuery(id));

            if (result == null)
                return NotFound(Result<string>.Failure($"No se encontró el usuario con ID {id}"));

            return Ok(result);
        }
    }
}

