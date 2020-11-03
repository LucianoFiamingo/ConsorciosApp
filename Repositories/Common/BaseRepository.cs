using Entities;
using Entities.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class BaseRepository<T> : IRepositorio<T> where T : class
    {
        protected PW3_TP_20202CEntities ctx;
        DbSet<T> dbSet;

        public BaseRepository(PW3_TP_20202CEntities contexto)
        {
            ctx = contexto;
            dbSet = ctx.Set<T>();
        }

        public virtual void Alta(T t)
        {
            dbSet.Add(t);
            ctx.SaveChanges();
        }

        public virtual List<T> ObtenerTodos()
        {
            return dbSet.ToList();
        }

        public virtual T ObtenerPorId(long id)
        {
            T t = dbSet.Find(id);

            return t;
        }

        public virtual void Eliminar(long id)
        {
            T t = ObtenerPorId(id);

            if (t != null)
            {
                dbSet.Remove(t);
            }

            ctx.SaveChanges();
        }

        public abstract void Modificar(T t);

    }
}