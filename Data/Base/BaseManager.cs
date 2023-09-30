using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public abstract class BaseManager<T> where T : class
    {
        #region Singleton
        protected static ApplicationDbContext _context;
        public static ApplicationDbContext ContextoSingleton
        {
            get
            {
                if (_context == null)
                    _context = new ApplicationDbContext();
                return _context;
            }
        }
        #endregion

        #region Metodos Abstractos
        public abstract Task<List<T>> BuscarLista();
        public abstract Task<T> Buscar();
        public abstract Task<bool> Eliminar(T modelo);
        #endregion

        #region Metodos Publicos
        public async Task<bool> Guardar(T modelo, int id)
        {
            if (id == 0)
                ContextoSingleton.Entry<T>(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                ContextoSingleton.Entry<T>(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            var resultado = await ContextoSingleton.SaveChangesAsync() > 0;
            ContextoSingleton.Entry<T>(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return resultado;
        }
        #endregion
    }
}
