using System;
using System.Collections.Generic;
using Entities;
using Entities.EDMX;
using Repositories;

namespace Services
{
    public class UnidadService : BaseService<UnidadRepository, Unidad>
    {
        public UnidadService(PW3_TP_20202CEntities contexto) : base(contexto)
        {
        }
        public IEnumerable<Unidad> ObtenerUnidadesPorIdConsorcio(int id, int idUsuarioCreador)
        {
            return repo.ObtenerUnidadesPorIdConsorcio(id , idUsuarioCreador);
        }
    }
}
