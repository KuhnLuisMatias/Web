using Data.Dto;
using Data.Entities;

namespace Web.Interfaces
{
    public interface IRecuperarCuentaService
    {
        Task<Usuarios?> BuscarUsuarios(LoginDto loginDto);
        bool GuardarCodigo(UsuariosDto usuarioDto);
    }
}
