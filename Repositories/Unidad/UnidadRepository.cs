

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
        public List<Unidad> ObtenerUnidadesPorConsorcioYOrdenadosPorNombre(int id, int idUsuarioCreador)
        {
            var Unidades =  from uni in ctx.Unidads
                            where uni.IdConsorcio == id && uni.Consorcio.IdUsuarioCreador == idUsuarioCreador
                            orderby uni.Nombre
                            select uni;

            List<Unidad> UnidadesPorConsorcio = Unidades.ToList();

            return UnidadesPorConsorcio;
        }
       
        public List<Consorcio> ObtenerConsorcio(int id)
        {
            var con = from c in ctx.Consorcios
                           where c.IdConsorcio == id 
                           select c;

            List<Consorcio> Consorcio = con.ToList();

            return Consorcio;
        }
        public Consorcio ObtenerPorIdConsorcio(int id)
        {
            Consorcio c;

            c = (from con in ctx.Consorcios
                 where con.IdConsorcio == id
                 select con).Single();

            return c;
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

        public Boolean ExisteNombre(string nombre, int id)
        {
            var encontrado = ctx.Unidads.Where(item => item.IdUsuarioCreador == id
                                            && item.Nombre == nombre).FirstOrDefault();

            if (encontrado != null)
            {
                return true;
            }
            return false;
        }

        public Boolean ExisteNombre(string nombre, int id, int idUni)
        {
            var encontrado = ctx.Unidads.Where(item => item.IdUsuarioCreador == id
                                            && item.Nombre == nombre
                                            && item.IdUnidad != idUni).FirstOrDefault();

            if (encontrado != null)
            {
                return true;
            }
            return false;
        }
    }
}