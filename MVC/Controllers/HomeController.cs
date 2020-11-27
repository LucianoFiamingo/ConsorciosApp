using Entities.EDMX;
using Services;
using System;
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
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult Ingresar()
        {
            if (!String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                return Redirect("/Consorcio/Listado");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Ingresar(Usuario us)
        {
            if (!ModelState.IsValid)
            {
                return View(us);
            }
            
            Usuario usLog = usuarioService.validarInicioSesion(us.Email, us.Password);
            if (usLog == null)
            {
                ViewBag.Invalido = true;
                return View(us);
            }

            Session["usuarioId"] = usLog.IdUsuario;
            
            usLog.FechaUltLogin = DateTime.Now;
            usuarioService.Modificar(usLog);

            return Redirect("/Consorcio/Listado");
        }

        public ActionResult Registrar()
        {
            if (!String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                return Redirect("/Consorcio/Listado");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            usuario.FechaRegistracion = DateTime.Now;
            usuarioService.Alta(usuario);

            Session["usuarioId"] = usuario.IdUsuario;
            usuario.FechaUltLogin = DateTime.Now;
            return Redirect("/Consorcio/Listado");
        }
        public ActionResult Salir()
        {
            HttpContext.Session.Abandon();
            return Redirect("/Home/Ingresar");
        }
    }
}