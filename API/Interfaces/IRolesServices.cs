using Data.Entities;

namespace API.Interfaces
{
    public interface IRolesServices
    {
        Task<List<Roles>> BuscarLista();
        Task<List<Roles>> Guardar(Roles rol);
        Task<bool> Eliminar(Roles rol);
    }
}
