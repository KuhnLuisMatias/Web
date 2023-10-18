using Data.Entities;

namespace API.Interfaces
{
    public interface IUsuariosServices
    {
        Task<List<Usuarios>> BuscarLista();
        Task<bool> Guardar(Usuarios usuario);
        Task<bool> Eliminar(Usuarios usuario);
    }
}
