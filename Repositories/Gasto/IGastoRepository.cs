using Entities.EDMX;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IGastoRepository
    {
        List<Gasto> ObtenerGastosPorConsorcio(int id , int idUsuarioCreador);
        Boolean ExisteNombre(string nombre, int id);
        Boolean ExisteNombre(string nombre, int id, int idCon);
    }
}
