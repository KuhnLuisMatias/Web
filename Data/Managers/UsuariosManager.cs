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
    public class UsuariosManager : BaseManager<Usuarios>
    {
        public override Task<Usuarios> Buscar()
        {
            throw new NotImplementedException();
        }

        public override async Task<List<Usuarios>> BuscarLista()
        {
            return await ContextoSingleton.Usuarios.Where(x => x.Activo).Include("Roles").ToListAsync();
        }

        public override async Task<bool> Eliminar(Usuarios modelo)
        {
            ContextoSingleton.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var resultado = await ContextoSingleton.SaveChangesAsync() > 0;
            ContextoSingleton.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return resultado;
        }
    }
}
