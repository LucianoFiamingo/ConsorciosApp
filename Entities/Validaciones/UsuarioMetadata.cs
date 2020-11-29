using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.EDMX
{
    internal class UsuarioMetadata
    {
        [Required(ErrorMessage = "Email es requerido")]
        [EmailAddress(ErrorMessage = "El email es invalido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "El password es requerido")]
        public string Password { get; set; }

        



    }
}