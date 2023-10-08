using Data.Entities;

namespace API.Interfaces
{
    public interface IUsuariosServices
    {
        Task<List<Usuarios>> BuscarLista();
        Task<List<Usuarios>> Guardar(Usuarios usuario);
        Task<bool> Eliminar(Usuarios usuario);
    }
}
