using API.Interfaces;
using Commons.Helpers;
using Data.Entities;
using Data.Managers;

namespace API.Services
{
    public class ServiciosServices : IServicioServices
    {
        private readonly ServiciosManager _manager;

        public ServiciosServices()
        {
            _manager = new ServiciosManager();
        }

        public async Task<List<Servicios>> BuscarLista()
        {
            try
            {
                throw new Exception("BuscarLista error forzado");
                return await _manager.BuscarLista();
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "Servicio", "BuscarLista");
                throw;
            }
        }

        public async Task<List<Servicios>> Guardar(Servicios servicio)
        {
            try
            {
                var resultado = await _manager.Guardar(servicio);
                return await _manager.BuscarLista();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Servicios servicio)
        {
            try
            {
                servicio.Activo = false;
                return await _manager.Eliminar(servicio);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
