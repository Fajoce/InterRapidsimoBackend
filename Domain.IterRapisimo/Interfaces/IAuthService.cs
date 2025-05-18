using Domain.IterRapisimo.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IterRapisimo.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginRequestDTO loginDto);

    }
}
