using Entities.EDMX;
using Newtonsoft.Json;
using Services.Gastos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApi_Expensas.Models;

namespace MVC.Controllers
{
    public class ExpensasController : Controller
    {
        GastosService gastosService;
       
        public ExpensasController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            this.gastosService = new GastosService(contexto);
        }

            public ActionResult Index()
        {
            List<ExpensaDTO> expensas = GetExpensas("1");
            return View(expensas);
        }

        private List<ExpensaDTO> GetExpensas(string id)
        {
            var url = $"https://localhost:44345/api/expensasdto/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GetAllPorConsorcio";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return new List<ExpensaDTO>();
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<List<ExpensaDTO>>(responseBody);
                        return result;
                    }
                }
            }
        }


    }
}