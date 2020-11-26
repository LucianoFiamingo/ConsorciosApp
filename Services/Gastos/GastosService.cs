using Entities.EDMX;
using Entities.VM;
using Repositories.Gasto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Services.Gastos
{
    public class GastosService : BaseService<GastoRepository,Gasto>, IGastosService
    {

      public GastosService(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }

        public List<Expensa> ObtenerDatosExpensaPorConsorcio(int id)
        {
            return repo.ObtenerDatosExpensaPorConsorcio(id);
        }

        

        public List<Gasto> ObtenerGastosPorConsorcio(int id)
        {
            return repo.ObtenerGastosPorConsorcio(id);
        }

        public Expensa ObtenerGastosTotalUltimoMes(int id)
        {
            return repo.ObtenerGastosTotalUltimoMes(id);
        }

        public int ObtenerTotalUnidadesPorConsorcio(int id)
        {
            return repo.ObtenerTotalUnidadesPorConsorcio(id);
        }
    }

   
}
