using Entities;
using Entities.EDMX;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IConsorcioRepository
    {
        List<Consorcio> ObtenerTodosOrdenadosPorNombre();

        Boolean ObtenerPorNombre(string nombre);
    }
}