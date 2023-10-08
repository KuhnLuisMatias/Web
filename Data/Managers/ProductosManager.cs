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
    public class ProductosManager : BaseManager<Productos>
    {
        public override Task<Productos> Buscar()
        {
            throw new NotImplementedException();
        }

        public override async Task<List<Productos>> BuscarLista()
        {
            return await ContextoSingleton.Productos.Where(x => x.Activo).ToListAsync();
        }

        public override async Task<bool> Eliminar(Productos modelo)
        {
            ContextoSingleton.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var resultado = await ContextoSingleton.SaveChangesAsync() > 0;
            ContextoSingleton.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return resultado;
        }
    }
}
