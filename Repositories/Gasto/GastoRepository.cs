using Entities.EDMX;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class GastoRepository : BaseRepository<Gasto>, IGastoRepository
    {
        
        
        public GastoRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }
        public override void Modificar(Gasto t)
        {
            Gasto gasto = ObtenerPorId(t.IdGasto);
            gasto.MesExpensa = t.MesExpensa;
            gasto.AnioExpensa = t.AnioExpensa;
            gasto.Monto = t.Monto;
            gasto.Nombre = t.Nombre;
            gasto.IdConsorcio = t.IdConsorcio;
            gasto.IdTipoGasto = t.IdTipoGasto;
            gasto.TipoGasto = t.TipoGasto;
            gasto.ArchivoComprobante = t.ArchivoComprobante;
            ctx.SaveChanges();

        }
        public List<Gasto> ObtenerGastosPorConsorcio(int id , int idUsuarioCreador)
        {
            var gasto = from Gasto in ctx.Gastoes
                        where Gasto.IdConsorcio == id && Gasto.IdUsuarioCreador == idUsuarioCreador
                        select Gasto;

            List<Gasto> gastosPorConsorcio = gasto.ToList();

            return gastosPorConsorcio;
        }
        
    }
}