using Entities;
using Entities.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class UnidadRepository : BaseRepository<Consorcio>
    {
        public UnidadRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }
        
    }
}