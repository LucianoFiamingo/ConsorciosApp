using System;
//using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Provincia
    {
        public long id { get; set; }

        //[Required(ErrorMessage = "Nombre de provincia requerido")]
        public string Nombre { get; set; }
    }
}
