using Entities.EDMX;
using Entities.VM;
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

            if (TempData["Redirect"] != null)
            {
                TempData["Redirect"] = TempData["Redirect"];
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

            if (TempData["Redirect"] != null && !String.IsNullOrEmpty(TempData["Redirect"].ToString()))
            {
                return Redirect(TempData["Redirect"].ToString());
            }

            return Redirect("/Consorcio/Listado");
        }

        public ActionResult Registrar()
        {
            if (!String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                return Redirect("/Consorcio/Listado");
            }
            return View(new UsuarioRegistroVM());
        }

        [HttpPost]
        public ActionResult Registrar(UsuarioRegistroVM usuarioVM)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarioVM);
            }
            if (usuarioService.existeEmail(usuarioVM.Email) != false)
            {
                ViewBag.Invalido = true;
                return View(usuarioVM);
            }
            
            Usuario usuario = new Usuario();
            usuario.Email = usuarioVM.Email;
            usuario.Password = usuarioVM.Password;

            usuario.FechaRegistracion = DateTime.Now;
            usuarioService.Alta(usuario);

            Session["usuarioId"] = usuario.IdUsuario;
            usuario.FechaUltLogin = DateTime.Now;
            return Redirect("Ingresar");
        }
        public ActionResult Salir()
        {
            HttpContext.Session.Abandon();
            return Redirect("/Home/Ingresar");
        }

        public ActionResult Error(int id = 0)
        {
            switch (id)
            {
                case 505:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.Description = "Esto es muy vergonzoso, esperemos que no vuelva a pasar ..";
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "La URL que está intentando ingresar no existe";
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Algo salio muy mal :( ..";
                    break;
            }

            return View();
        }
    }
}