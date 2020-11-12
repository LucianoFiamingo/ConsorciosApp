using Entities.EDMX;
using Repositories.Gasto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Gastos
{
   public class TipoGastoService : BaseService<TipoGastoRepository,TipoGasto>, ITipoGastoService
    {
        public TipoGastoService(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }
    }
}
