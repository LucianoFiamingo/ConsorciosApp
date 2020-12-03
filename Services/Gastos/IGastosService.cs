using Entities.EDMX;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IGastosService
    {
        List<Gasto> ObtenerGastosPorConsorcio(int id , int idUsuarioCreador);
        Boolean ExisteNombre(string nombre, int id);
        Boolean ExisteNombre(string nombre, int id, int idCon);
    }
}
