using API.Interfaces;
using Commons.Helpers;
using Data.Entities;
using Data.Managers;

namespace API.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly UsuariosManager _manager;

        public UsuariosServices()
        {
            _manager = new UsuariosManager();
        }

        public async Task<List<Usuarios>> BuscarLista()
        {
            try
            {
                return await _manager.BuscarLista();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Usuarios>> Guardar(Usuarios usuario)
        {
            try
            {
                usuario.Clave = EncryptHelper.Encriptar(usuario.Clave);
                var resultado = await _manager.Guardar(usuario, usuario.Id);
                return await _manager.BuscarLista();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Usuarios usuario)
        {
            try
            {
                usuario.Activo = false;
                return await _manager.Eliminar(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
