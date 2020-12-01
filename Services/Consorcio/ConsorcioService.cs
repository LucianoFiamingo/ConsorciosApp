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
        
        public List<Consorcio> ObtenerTodosOrdenadosPorNombre(int id)
        {
            return repo.ObtenerTodosOrdenadosPorNombre(id);
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
