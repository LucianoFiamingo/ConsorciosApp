using Entities.EDMX;
using System.Collections.Generic;

namespace Services
{
    public interface IGastosService
    {
        List<Gasto> ObtenerGastosPorConsorcio(int id , int idUsuarioCreador);
    }
}
