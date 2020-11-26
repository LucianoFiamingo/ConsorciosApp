using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Expensas.Models
{
    public class ExpensaDTO
    {

    

        public int anio { get; set; }

        public int mes { get; set; }

        public int gastoTotal { get; set; }

        public int expensaPorUnidad { get; set; }

        public int cantidadUnidades { get; set; }

    }
}