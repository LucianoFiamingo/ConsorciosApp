using Entities;
using Entities.EDMX;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IConsorcioRepository
    {
        List<Consorcio> ObtenerTodosOrdenadosPorNombre();
        List<Consorcio> ObtenerTodosOrdenadosPorNombre(int id);
        Boolean ExisteNombre(string nombre, int id);
    }
}