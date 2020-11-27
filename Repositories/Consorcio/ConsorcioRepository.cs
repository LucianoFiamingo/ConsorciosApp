using Entities;
using Entities.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class ConsorcioRepository : BaseRepository<Consorcio>, IConsorcioRepository
    {
        public ConsorcioRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }
        public override void Modificar(Consorcio t)
        {
            Consorcio cons = ObtenerPorId(t.IdConsorcio);
            cons.Nombre = t.Nombre;
            cons.IdProvincia = t.IdProvincia;
            cons.Ciudad = t.Ciudad;
            cons.Calle = t.Calle;
            cons.Altura = t.Altura;
            cons.DiaVencimientoExpensas = t.DiaVencimientoExpensas;
            cons.Gastoes = t.Gastoes;

            ctx.SaveChanges();
        }

        public List<Consorcio> ObtenerTodosOrdenadosPorNombre()
        {
            return ctx.Consorcios.OrderBy(item => item.Nombre).ToList();
        }
        
        public List<Consorcio> ObtenerTodosOrdenadosPorNombre(int id)
        {
            return ctx.Consorcios.Where(item => item.IdUsuarioCreador == id)
                                 .OrderBy(item => item.Nombre).ToList();
        }

        public Boolean ExisteNombre(string nombre)
        {
            var encontrado = ctx.Consorcios.Where(item => item.Nombre == nombre).FirstOrDefault();

            if (encontrado != null)
            {
                return true;
            }
            return false;
        }
    }
}