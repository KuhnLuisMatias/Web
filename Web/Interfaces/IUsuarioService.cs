using Data.Dto;
using Data.Entities;

namespace Web.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuarios> BuscarUsuario(LoginDto loginDto);
    }
}
