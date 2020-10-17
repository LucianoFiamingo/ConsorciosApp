using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Content
{
    public class Usuario
    {
        [Required(ErrorMessage ="Nombre de usuario requerido")]
        public string NombreUsuario { get; set; }
        
        [Required(ErrorMessage = "Email requerido")]
        [EmailAddress(ErrorMessage ="Formato de email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [Compare("Email" , ErrorMessage = "Los emails deben coincidir")]
        [Display(Name = "Reingresar email")]
        public string ReEmail { get; set; }
    }
}