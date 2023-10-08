using Data.Base;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Managers
{
    public class ServiciosManager : BaseManager<Servicios>
    {
        public override Task<Servicios> Buscar()
        {
            throw new NotImplementedException();
        }

        public override async Task<List<Servicios>> BuscarLista()
        {
            return await ContextoSingleton.Servicios.FromSqlRaw("ObtenerServicios").ToListAsync();
        }

        public override async Task<bool> Eliminar(Servicios servicio)
        {
            return Convert.ToBoolean(ContextoSingleton.Database.ExecuteSqlRaw($"EliminarServicio {servicio.Id}"));
        }

        public async Task<bool> Guardar(Servicios servicio)
        {
            return Convert.ToBoolean(ContextoSingleton.Database.ExecuteSqlRaw($"GuardarServicio {servicio.Id},{servicio.Nombre}, {servicio.Activo}"));
        }
    }
}
