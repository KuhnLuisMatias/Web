using API.Interfaces;
using Data.Entities;
using Data.Managers;

namespace API.Services
{
    public class ProductosServices : IProductosServices
    {
        private readonly ProductosManager _manager;

        public ProductosServices()
        {
            _manager = new ProductosManager();
        }

        public async Task<List<Productos>> BuscarLista()
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

        public async Task<List<Productos>> Guardar(Productos producto)
        {
            try
            {
                var resultado = await _manager.Guardar(producto, producto.Id);
                return await _manager.BuscarLista();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Productos producto)
        {
            try
            {
                producto.Activo = false;
                return await _manager.Eliminar(producto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
