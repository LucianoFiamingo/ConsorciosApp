using Entities.EDMX;
using Services.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        UsuarioService usuarioService;

        public HomeController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            this.usuarioService = new UsuarioService(contexto);
        

        }

        public ActionResult Home()
        {
            return View();
        }

       
        public ActionResult Ingresar()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Ingresar(String email , String password)
        {
            Usuario usu = usuarioService.validarInicioSesion(email, password);
           if (usu== null)
            {
                return Redirect("Home/Ingresar");
            }
            else
            {
                Session["usuarioId"] = usu.IdUsuario;

                return Redirect("");
            }
        }
       
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {
            usuarioService.Alta(usuario);
            return RedirectToAction("Ingresar");
        }
    }
}