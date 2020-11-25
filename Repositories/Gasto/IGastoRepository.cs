using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Gasto
{
    public interface ITipoGastoRepository
    {
        List<Entities.EDMX.Gasto> ObtenerGastosPorConsorcio(int id);
    }
}
