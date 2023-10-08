using API.Interfaces;
using Data.Entities;
using Data.Managers;

namespace API.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly RolesManager _manager;

        public RolesServices()
        {
            _manager = new RolesManager();
        }

        public async Task<List<Roles>> BuscarLista()
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

        public async Task<List<Roles>> Guardar(Roles rol)
        {
            try
            {
                var resultado = await _manager.Guardar(rol, rol.Id);
                return await _manager.BuscarLista();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Roles rol)
        {
            try
            {
                rol.Activo = false;
                return await _manager.Eliminar(rol);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
