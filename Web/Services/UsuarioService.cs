using Data.Dto;
using Data.Entities;
using Data.Managers;

namespace Web.Services
{
    public class UsuarioService
    {
        private readonly UsuariosManager _manager;

        public UsuarioService()
        {
            _manager = new UsuariosManager();
        }
        public async Task<Usuarios> BuscarUsuario(LoginDto loginDto)
        {
            return await _manager.BuscarUsuarioGoogleAsync(loginDto);
        }
    }
}
