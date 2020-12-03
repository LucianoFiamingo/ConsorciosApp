using Entities.EDMX;
using Repositories;
using System;
using System.Collections.Generic;

namespace Services
{
    public class GastosService : BaseService<GastoRepository,Gasto>, IGastosService
    {
       
      public GastosService(PW3_TP_20202CEntities contexto) : base(contexto)
        {
        }
        public List<Gasto> ObtenerGastosPorConsorcio(int id , int idUsuarioCreador)
        {
            return repo.ObtenerGastosPorConsorcio(id , idUsuarioCreador);
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
