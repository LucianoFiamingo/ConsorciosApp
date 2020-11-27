using Entities.EDMX;
using Repositories;
using System.Collections.Generic;

namespace Services
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
