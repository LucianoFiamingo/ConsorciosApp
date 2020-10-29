using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.EDMX
{
    internal class UsuarioMetadata
    {
        [Required(ErrorMessage = "Email es requerido")]
        [EmailAddress(ErrorMessage = "El email es invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(12, ErrorMessage = "El numero maximo de caracteres es veinte")]
        public string Password { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "La fecha de registracion es requerida")]
        public System.DateTime FechaRegistracion { get; set; }
    }
}