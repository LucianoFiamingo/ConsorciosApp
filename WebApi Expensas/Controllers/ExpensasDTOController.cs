using Entities.DTO;
using Entities.EDMX;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi_Expensas.Controllers
{
    public class ExpensasDTOController : ApiController
    {
        ExpensasService ExpensasService;

        public ExpensasDTOController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            this.ExpensasService = new ExpensasService(contexto);
        }

        public ExpensaDTO Get(int id)
        {
            ExpensaDTO expensas = ExpensasService.ObtenerDatosExpensaPorConsorcio(id);
            return expensas;
        }
    }
}
