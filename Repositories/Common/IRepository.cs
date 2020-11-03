using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    interface IRepositorio<T>
    {
        void Alta(T t);

        List<T> ObtenerTodos();

        T ObtenerPorId(long id);

        void Eliminar(long id);

        void Modificar(T t);

    }
}