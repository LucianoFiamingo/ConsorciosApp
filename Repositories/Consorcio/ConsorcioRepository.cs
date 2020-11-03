﻿using Entities;
using Entities.EDMX;
using System.Collections.Generic;

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
        public Consorcio ObtenerConsorcioCompleto(long? IdConsorcio)
        {
            Consorcio cons = ctx.Consorcios.Find(IdConsorcio);
            return cons;
        }
    }
}