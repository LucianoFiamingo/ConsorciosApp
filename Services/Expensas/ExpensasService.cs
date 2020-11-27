using System;
using System.Collections.Generic;
using Entities;
using Entities.DTO;
using Entities.EDMX;
using Repositories;

namespace Services
{
    public class ExpensasService : IExpensasService
    {
        protected ExpensasRepository repo;
        public ExpensasService(PW3_TP_20202CEntities contexto)
        {
            this.repo = new ExpensasRepository(contexto);
        }
        public ExpensaDTO ObtenerDatosExpensaPorConsorcio(int id)
        {
            return repo.ObtenerDatosExpensaPorConsorcio(id);
        }
        public int ObtenerTotalUnidadesPorConsorcio(int id)
        {
            return repo.ObtenerTotalUnidadesPorConsorcio(id);
        }
    }
}
