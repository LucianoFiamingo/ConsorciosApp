using Entities.EDMX;
using Entities.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Gasto
{
    public class GastoRepository : BaseRepository<Entities.EDMX.Gasto>, ITipoGastoRepository
    {
        public GastoRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }

        public override void Modificar(Entities.EDMX.Gasto t)
        {
            Entities.EDMX.Gasto gasto = ObtenerPorId(t.IdGasto);
            gasto.MesExpensa = t.MesExpensa;
            gasto.Monto = t.Monto;
            gasto.Nombre = t.Nombre;
            gasto.IdConsorcio = t.IdConsorcio;
            gasto.IdTipoGasto = t.IdTipoGasto;
            gasto.IdUsuarioCreador = t.IdUsuarioCreador;
            gasto.TipoGasto = t.TipoGasto;
            gasto.Usuario = t.Usuario;

            ctx.SaveChanges();

        }
        public List<Entities.EDMX.Gasto> ObtenerGastosPorConsorcio(int id)
        {
            var gasto = from Gasto in ctx.Gastoes
                        where Gasto.IdConsorcio == id
                        select Gasto;
            List<Entities.EDMX.Gasto> gastosPorConsorcio = gasto.ToList();

            return gastosPorConsorcio;
        }

        public Expensa ObtenerGastosTotalUltimoMes(int id)
        {
            var expensaQuery = from g in ctx.Gastoes
                               where g.IdConsorcio == id &&  g.MesExpensa.Equals(DateTime.Now.Month) && g.AnioExpensa.Equals(DateTime.Now.Year)
                               group g by new
                               {
                                   g.MesExpensa,
                                   g.AnioExpensa,
                                   g.IdConsorcio
                               } into g
                               select new Expensa
                               {
                                   anio = g.Key.AnioExpensa,
                                   mes = g.Key.MesExpensa,
                                   gastoTotal = (int)g.Sum(x => x.Monto)
                               };

            Expensa datosExpensa = expensaQuery.First();

            return datosExpensa;
        }

        public int ObtenerTotalUnidadesPorConsorcio(int id)
        {
            var UnidadQuery = (from u in ctx.Unidads
                               where u.IdConsorcio == id
                               select u).Count();

            return UnidadQuery;
        }

        public List<Expensa> ObtenerDatosExpensaPorConsorcio(int id)
        {
            var expensaQuery = from g in ctx.Gastoes
                               where g.IdConsorcio == id
                               group g by new
                               {
                                   g.MesExpensa,
                                   g.AnioExpensa
                               }  into g
                               select new Expensa
                               {
                                   anio = g.Key.AnioExpensa,
                                   mes = g.Key.MesExpensa,
                                   gastoTotal = (int)g.Sum(x => x.Monto)
                               };

            List<Expensa> datosExpensa = expensaQuery.ToList();

            return datosExpensa;
                             
        }
    }
}