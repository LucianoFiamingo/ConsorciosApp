using System;
using System.Collections.Generic;
using Entidades;

namespace Servicios
{
    public class ConsorcioService : IConsorcioService
    {
        public List<Consorcio> GetAll()
        {
            Consorcio consorcio1 = new Consorcio() { Altura = 1 };
            Consorcio consorcio2 = new Consorcio() { Altura = 1 };
            
            List<Consorcio> consorcios = new List<Consorcio>() {consorcio1, consorcio2};
            return consorcios;
        }
    }
}
