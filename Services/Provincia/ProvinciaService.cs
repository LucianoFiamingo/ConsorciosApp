using System;
using System.Collections.Generic;
using Entities;
using Entities.EDMX;
using Repositories;

namespace Services
{
    public class ProvinciaService : BaseService<ProvinciaRepository, Provincia>, IProvinciaService
    {
        public ProvinciaService(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }
    }
}
