using Data.Entities;

namespace Web.ViewModels
{
    public class ServiciosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public static implicit operator ServiciosViewModel(Servicios v)
        {
            var servicioViewModel = new ServiciosViewModel()
            {
                Id = v.Id,
                Nombre = v.Nombre,
                Activo = v.Activo
            };
            return servicioViewModel;
        }
    }
}
