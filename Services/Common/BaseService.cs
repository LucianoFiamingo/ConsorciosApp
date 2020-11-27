using Entities;
using Entities.EDMX;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService<T, J> : IService<J> where T : BaseRepository<J> where J : class
    {
        protected T repo;
        public BaseService(PW3_TP_20202CEntities contexto)
        {
            PW3_TP_20202CEntities ctx = contexto;
            repo = Activator.CreateInstance(typeof(T), new object[] { contexto }) as T;
        }

        public void Alta(J j)
        {
            
            repo.Alta(j);
        }

        public void Eliminar(long id)
        {
            repo.Eliminar(id);
        }

        public void Modificar(J j)
        {
            repo.Modificar(j);
        }

        public J ObtenerPorId(long id)
        {
            return repo.ObtenerPorId(id);
        }

        public List<J> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }
    }
}