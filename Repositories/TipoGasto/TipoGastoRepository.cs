using Entities.EDMX;

namespace Repositories
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
