using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Entities;
using Entities.DTO;
using Entities.EDMX;
using Newtonsoft.Json;
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
        public ExpensaDTO GetExpensas(int id)
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
