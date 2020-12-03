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

        public Boolean ExisteNombre(string nombre, int idUsuCre, int idCon)
        {
            return repo.ExisteNombre(nombre, idUsuCre, idCon);
        }

        public Boolean ExisteNombre(string nombre, int idUsuCre, int idCon, int idUni)
        {
            return repo.ExisteNombre(nombre, idUsuCre, idCon, idUni);
        }
    }
}
