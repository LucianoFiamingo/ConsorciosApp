using Entities.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Gasto
{
   public class TipoGastoRepository : BaseRepository<TipoGasto>, ITipoGastoRepository
    {

        public TipoGastoRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }

        public override void Modificar(TipoGasto t)
        {
            TipoGasto tipo = ObtenerPorId(t.IdTipoGasto);
            tipo.Nombre = t.Nombre;

            ctx.SaveChanges();
        }
    }
}
