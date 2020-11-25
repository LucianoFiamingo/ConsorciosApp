using Entities.EDMX;
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

        public List<Gasto> ObtenerGastosPorConsorcio(int id)
        {
            return repo.ObtenerGastosPorConsorcio(id);
        }
    }

   
}
