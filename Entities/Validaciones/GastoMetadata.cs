using System.ComponentModel.DataAnnotations;

namespace Entities.EDMX
{
    internal class GastoMetadata
    {

       
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(20, ErrorMessage = "El numero maximo de caracteres es veinte")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Descripcion es requerido")]
        [MaxLength(20, ErrorMessage = "El numero maximo de caracteres es 20")]
        public string Descripcion { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "La fecha del gasto es requerida")]
        public System.DateTime FechaGasto { get; set; }
        [Required(ErrorMessage = "Debe elegir un consorcio")]
        public int IdConsorcio { get; set; }
        [Required(ErrorMessage = "Debe elegir un tipo de gasto")]
        public int IdTipoGasto { get; set; }

        public int AnioExpensa { get; set; }
        public int MesExpensa { get; set; }
        public string ArchivoComprobante { get; set; }
        public decimal Monto { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    }
}