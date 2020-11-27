using Entities.DTO;
using Entities.EDMX;
using Newtonsoft.Json;
using Services;
using Services.Gastos;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ExpensasController : Controller
    {
        ConsorcioService ConsorcioService;

        public ExpensasController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            ConsorcioService = new ConsorcioService(contexto);
        }

        public ActionResult Ver(int? id)
        {
            if (id == null)
            {
                return Redirect("/Consorcio/Listado");
            }
            ViewBag.NombreConsorcio = ConsorcioService.ObtenerPorId((int)id).Nombre;
            ExpensaDTO expensas = GetExpensas((int)id);
            return View(expensas);
        }

        private ExpensaDTO GetExpensas(int id)
        {
            var url = $"https://localhost:44345/api/expensasdto/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return new ExpensaDTO();
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<ExpensaDTO>(responseBody);
                        return result;
                    }
                }
            }
        }


    }
}