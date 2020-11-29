

using Entities;
using Entities.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class UnidadRepository : BaseRepository<Unidad>
    {
        public UnidadRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }
        public IEnumerable<Unidad> ObtenerUnidadesPorIdConsorcio(int id, int idUsuarioCreador)
        {
            IEnumerable<Unidad> g;

            g = from u in ctx.Unidads
                where u.IdConsorcio == id && u.Consorcio.IdUsuarioCreador == idUsuarioCreador
                select u;

            return g;
        }
        public override void Modificar(Unidad t)
        {
            Unidad uni = ObtenerPorId(t.IdUnidad);
            uni.Nombre = t.Nombre;
            uni.NombrePropietario = t.NombrePropietario;
            uni.ApellidoPropietario = t.ApellidoPropietario;
            uni.EmailPropietario = t.EmailPropietario;
            uni.Superficie = t.Superficie;

            ctx.SaveChanges();
        }
    }
}