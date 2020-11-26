using Entities.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Services.Gastos
{
    public interface IGastosService
    {
        List<Entities.EDMX.Gasto> ObtenerGastosPorConsorcio(int id);


        Expensa ObtenerGastosTotalUltimoMes(int id);


        int ObtenerTotalUnidadesPorConsorcio(int id);

        List<Expensa> ObtenerDatosExpensaPorConsorcio(int id);
    }
}
