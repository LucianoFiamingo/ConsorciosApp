using System;
using System.Collections.Generic;
using Entities.EDMX;

namespace Servicios
{
    public class ConsorcioService : IConsorcioService
    {
        public List<Consorcio> GetAll()
        {
            Consorcio consorcio1 = new Consorcio() { Nombre = "Edificio San Martin", IdProvincia = 1, Ciudad = "CABA", Calle = "Avenida San Martin", Altura = 1 };
            Consorcio consorcio2 = new Consorcio() { Nombre = "Torres Altas", IdProvincia = 1, Ciudad = "CABA", Calle = "Avenida Congreso", Altura = 1 };
            
            List<Consorcio> consorcios = new List<Consorcio>() {consorcio1, consorcio2};
            return consorcios;
        }
    }
}
