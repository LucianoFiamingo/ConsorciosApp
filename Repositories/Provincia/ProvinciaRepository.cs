using Entities;
using Entities.EDMX;
using System.Collections.Generic;

namespace Repositories
{
    public class ProvinciaRepository : BaseRepository<Provincia>, IProvinciaRepository
    {
        public ProvinciaRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }
        public override void Modificar(Provincia t)
        {
            Provincia prov = ObtenerPorId(t.IdProvincia);
            prov.Nombre = t.Nombre;
            prov.IdProvincia = t.IdProvincia;

            ctx.SaveChanges();
        }
    }
}