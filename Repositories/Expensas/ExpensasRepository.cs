using Entities.DTO;
using Entities.EDMX;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class ExpensasRepository : IExpensasRepository
    {
        protected PW3_TP_20202CEntities ctx;

        public ExpensasRepository(PW3_TP_20202CEntities contexto)
        {
            this.ctx = contexto;
        }
        public ExpensaDTO ObtenerDatosExpensaPorConsorcio(int id)
        {
            int cantUnids = ObtenerTotalUnidadesPorConsorcio(id);

            var gastosQuery = from g in ctx.Gastoes
                               where g.IdConsorcio == id
                               group g by new
                               {
                                   g.MesExpensa,
                                   g.AnioExpensa
                               } into g
                               select new GastoDTO
                               {
                                   Anio = g.Key.AnioExpensa,
                                   Mes = g.Key.MesExpensa,
                                   GastoTotal = (int)g.Sum(x => x.Monto),
                                   ExpensaPorUnidad = ((int)g.Sum(x => x.Monto) / cantUnids)
                               };

            List<GastoDTO> gastos = gastosQuery.ToList();

            ExpensaDTO expensas = new ExpensaDTO();
            expensas.GastosMes = gastos;
            expensas.CantidadUnidades = cantUnids;

            return expensas;
        }
        public int ObtenerTotalUnidadesPorConsorcio(int id)
        {
            var UnidadQuery = (from u in ctx.Unidads
                               where u.IdConsorcio == id
                               select u).Count();

            return UnidadQuery;
        }
    }
}
