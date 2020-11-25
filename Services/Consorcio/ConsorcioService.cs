using System;
using System.Collections.Generic;
using Entities;
using Entities.EDMX;
using Repositories;

namespace Services
{
    public class ConsorcioService : BaseService<ConsorcioRepository, Consorcio>, IConsorcioService
    {
        public ConsorcioService(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }

        public List<Consorcio> ObtenerTodosOrdenadosPorNombre()
        {
            return repo.ObtenerTodosOrdenadosPorNombre();
        } 
        
        public Boolean ObtenerPorNombre(string nombre)
        {
            return repo.ObtenerPorNombre(nombre);
        }
    }
}
