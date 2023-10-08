using Data.Entities;

namespace API.Interfaces
{
    public interface IServicioServices
    {
        Task<List<Servicios>> BuscarLista();
        Task<List<Servicios>> Guardar(Servicios servicio);
        Task<bool> Eliminar(Servicios servicio);
    }
}
