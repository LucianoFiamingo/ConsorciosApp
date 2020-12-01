using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.EDMX
{
    internal class UnidadMetadata
    {

        [Required(ErrorMessage = "Debe proporcionar el consorcio")]
        public int IdConsorcio { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(20, ErrorMessage = "El numero maximo de caracteres es veinte")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Nombre del propietario es requerido")]
        [MaxLength(20, ErrorMessage = "El numero maximo de caracteres es veinte")]
        public string NombrePropietario { get; set; }

        [Required(ErrorMessage = "Apellido del propietario es requerido")]
        [MaxLength(20, ErrorMessage = "El numero maximo de caracteres es veinte")]
        public string ApellidoPropietario { get; set; }

        [Required(ErrorMessage = "Email del propietario es requerido")]
        [EmailAddress(ErrorMessage ="El email es invalido")]
        public string EmailPropietario { get; set; }

        [Required(ErrorMessage = "Debe proporcionar la superficie")]
        /*[RegularExpression("^[0-9]$")]*/
        [Range(0, 2000, ErrorMessage = "Superficie invalida")]
        public Nullable<int> Superficie { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "La fecha de creacion es requerida")]
        public System.DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "Debe elegir un usuario")]
        public int IdUsuarioCreador { get; set; }

        [Required(ErrorMessage = "Debe elegir un consorcio")]
        public virtual Consorcio Consorcio { get; set; }

        [Required(ErrorMessage = "Debe elegir un usuario")]
        public virtual Usuario Usuario { get; set; }
    }
}