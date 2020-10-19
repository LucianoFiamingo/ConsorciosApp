using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Unidad
    {
        public long idUnidad { get; set; }
        public long idConsorcio { get; set; }
        public string Nombre { get; set; }
        public string NombrePropetario { get; set; }
        public string ApellidoPropetario { get; set; }
        public string EmailPropetario { get; set; }
        public double Superficie { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long idUsuarioCreador { get; set; }
    }
}
