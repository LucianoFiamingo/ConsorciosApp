using Entities.EDMX;
using System.Collections.Generic;

namespace Repositories
{
    public interface IGastoRepository
    {
        List<Gasto> ObtenerGastosPorConsorcio(int id);
    }
}
