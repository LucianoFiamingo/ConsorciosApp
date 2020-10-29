using System.ComponentModel.DataAnnotations;

namespace Entities.EDMX
{
    internal class TipoGastoMetadata
    {

        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(20, ErrorMessage = "El numero maximo de caracteres es veinte")]
        public string Nombre { get; set; }
    }
}