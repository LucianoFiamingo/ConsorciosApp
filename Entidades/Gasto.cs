using System;
//using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Gasto
    {
        public long idGasto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long idConsorcio { get; set; }
        public long idTipoGasto { get; set; }
        public DateTime FechaGasto { get; set; }
        public DateTime AnioExpensa { get; set; }
        public DateTime MesExpensa { get; set; }
        
        /*
        public long ArchivoComprobante { get; set; }
        */
        public double Monto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long idUsuarioCreador { get; set; }
    }
}
