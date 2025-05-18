using Application.InerRapisimo.DTOs.Usuarios;

namespace Application.InerRapisimo.Repositories
{
    public interface IUsuariosService
    {
        Task<(string Token, int UsuarioEmail, string UsuarioPassword)> AutenticarJwtAsync(UsuarioLoginDTO loginDto);
        Task<CreateUsuarioDTO> VerMisDatos(int id);
        Task<bool> CreatePaciente(CreateUsuarioDTO paciente);
    }
}
