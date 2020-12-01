using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.VM
{
    public class UsuarioRegistroVM
    {
        [Required(ErrorMessage = "Email es requerido")]
        [EmailAddress(ErrorMessage = "El email es invalido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(50, ErrorMessage = "La Contraseña debe ser de 8 a 50 caracteres", MinimumLength = 8)]
        [RegularExpression("^(?=(.*\\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\\d]).{6,}$", 
            ErrorMessage ="La contraseña debe contener al menos una mayúscula, una minuscula, un numero y un simbolo")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La repetición de la contraseña es requerida")]
        [StringLength(50, ErrorMessage = "La Contraseña debe ser de 8 a 50 caracteres", MinimumLength = 8)]
        [RegularExpression("^(?=(.*\\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\\d]).{6,}$",
            ErrorMessage = "La contraseña debe contener al menos una mayúscula, una minuscula, un numero y un simbolo")]
        [Compare("Password", ErrorMessage = "Ambas contraseñas deben ser iguales")]
        public string Password2 { get; set; }


    }
}