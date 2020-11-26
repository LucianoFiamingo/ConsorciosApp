using Entities.EDMX;
using Entities.VM;
using Services.Gastos;
using System.Collections.Generic;
using System.Web.Http;
using WebApi_Expensas.Models;

namespace WebApi_Expensas.Controllers
{
    public class ExpensasDTOController : ApiController
    {
        GastosService gastosService;

        public ExpensasDTOController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            this.gastosService = new GastosService(contexto);

        }
            

       
        public IEnumerable<ExpensaDTO> GetAllPorConsorcio(int id)
        {
            List<Expensa> gastos = gastosService.ObtenerDatosExpensaPorConsorcio(id);
            var unidades = gastosService.ObtenerTotalUnidadesPorConsorcio(id);
            List<ExpensaDTO> expensas= new List<ExpensaDTO>();

            foreach(var gasto in gastos)
            {
                ExpensaDTO expensaDTO = new ExpensaDTO()
                {
                    anio = gasto.anio,
                    gastoTotal = gasto.gastoTotal,
                    cantidadUnidades= unidades,
                    mes=gasto.mes,
                    expensaPorUnidad=gasto.gastoTotal/unidades

                };
                expensas.Add(expensaDTO);
            }
            
            return expensas;
        }

      
        public ExpensaDTO GetUltimoMes(int id)
        {
            var unidades = gastosService.ObtenerTotalUnidadesPorConsorcio(id);
            var gasto = gastosService.ObtenerGastosTotalUltimoMes(id);
           

            ExpensaDTO expensa = new ExpensaDTO()
            {
                anio = gasto.anio,
                gastoTotal = gasto.gastoTotal,
                cantidadUnidades = unidades,
                mes = gasto.mes,
                expensaPorUnidad = (gasto.gastoTotal / unidades)

            };
          
        
            return expensa;
        }

  
    }
}
