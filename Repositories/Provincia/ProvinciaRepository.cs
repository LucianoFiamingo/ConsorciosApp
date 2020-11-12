using Entities;
using Entities.EDMX;
using System.Collections.Generic;

namespace Repositories
{
    public class UsuarioRepository : BaseRepository<Provincia>, IProvinciaRepository
    {
        public UsuarioRepository(PW3_TP_20202CEntities contexto) : base(contexto)
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