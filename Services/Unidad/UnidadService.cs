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
        public List<Unidad> ObtenerUnidadesPorConsorcioYOrdenadosPorNombre(int id, int idUsuarioCreador)
        {
            return repo.ObtenerUnidadesPorConsorcioYOrdenadosPorNombre(id , idUsuarioCreador);
        }
        public Consorcio ObtenerPorIdConsorcio(int id)
        {
            return repo.ObtenerPorIdConsorcio(id);
        }

        public Boolean ExisteNombre(string nombre, int id)
        {
            return repo.ExisteNombre(nombre, id);
        }

        public Boolean ExisteNombre(string nombre, int id, int idCon)
        {
            return repo.ExisteNombre(nombre, id, idCon);
        }
    }
}
