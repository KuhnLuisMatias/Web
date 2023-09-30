using Data.Entities;

namespace API.Interfaces
{
    public interface IProductosServices
    {
        Task<List<Productos>> BuscarLista();
        Task<List<Productos>> Guardar(Productos producto); 
    }
}
