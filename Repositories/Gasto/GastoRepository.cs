using Entities.EDMX;
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
    }
}