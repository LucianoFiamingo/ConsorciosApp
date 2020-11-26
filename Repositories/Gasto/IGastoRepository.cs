using Entities.VM;
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


        Expensa ObtenerGastosTotalUltimoMes(int id);

        int ObtenerTotalUnidadesPorConsorcio(int id);

        List<Expensa> ObtenerDatosExpensaPorConsorcio(int id);
    }

  
}
