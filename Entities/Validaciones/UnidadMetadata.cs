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
        [Display(Name = "Nombre del Propietario")]
        public string NombrePropietario { get; set; }

        [Required(ErrorMessage = "Apellido del propietario es requerido")]
        [MaxLength(20, ErrorMessage = "El numero maximo de caracteres es veinte")]
        [Display(Name = "Apellido del Propietario")]
        public string ApellidoPropietario { get; set; }

        [Required(ErrorMessage = "Email del propietario es requerido")]
        [EmailAddress(ErrorMessage ="El email es invalido")]
        [Display(Name = "Email del Propietario")]
        public string EmailPropietario { get; set; }

        [Required(ErrorMessage = "Debe proporcionar la superficie")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Ingrese un valor númerico entero")]
        [Range(0, int.MaxValue, ErrorMessage = "Superficie ")]
        public Nullable<int> Superficie { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "La fecha de creacion es requerida")]
        public System.DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "El usuario creador es requerido")]
        public int IdUsuarioCreador { get; set; }

        public virtual Consorcio Consorcio { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}