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
    public class RolesManager : BaseManager<Roles>
    {
        public override Task<Roles> Buscar()
        {
            throw new NotImplementedException();
        }

        public override async Task<List<Roles>> BuscarLista()
        {
            return await ContextoSingleton.Roles.Where(x => x.Activo).ToListAsync();
        }

        public override async Task<bool> Eliminar(Roles modelo)
        {
            ContextoSingleton.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var resultado = await ContextoSingleton.SaveChangesAsync() > 0;
            ContextoSingleton.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return resultado;
        }
    }
}
