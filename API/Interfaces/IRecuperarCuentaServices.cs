using Data.Dto;
using Data.Entities;

namespace API.Interfaces
{
    public interface IRecuperarCuentaServices
    {
        public bool GuardarCodigo(Usuarios usuarios);
        Usuarios BuscarUsuario(LoginDto login);
    }
}
