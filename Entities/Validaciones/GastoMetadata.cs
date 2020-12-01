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

        [Required(ErrorMessage = "Debe proporcionar el año de la expensa")]
        //[RegularExpression("/^[0-9]$/")]
        [Range(1980, 2030, ErrorMessage = "Año invalido")]
        public int AnioExpensa { get; set; }

        [Required(ErrorMessage = "Debe proporcionar el mes de la expensa")]
        public int MesExpensa { get; set; }

        [Required(ErrorMessage = "Debe subir el archivo")]
        public string ArchivoComprobante { get; set; }

        [Required(ErrorMessage = "Debe proporcionar el monto")]
        //[RegularExpression("/^[0-9]$/")]
        public decimal Monto { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "La fecha de creacion es requerida")]
        public System.DateTime FechaCreacion { get; set; }
    }
}