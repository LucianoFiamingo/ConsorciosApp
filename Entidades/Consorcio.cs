using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Consorcio
    {
        public long idConsorcio { get; set; }
        public string Nombre { get; set; }
        public long idProvincia { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public DateTime DiaVencimientoExensas { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long idUsuarioCreador { get; set; }
    }
}
