using Entities;
using Entities.EDMX;
using Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ConsorcioController : Controller
    {
        ConsorcioService ConsorcioService;
        ProvinciaService ProvinciaService;
        BreadcrumpService BreadcrumpService;

        public ConsorcioController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            ConsorcioService = new ConsorcioService(contexto);
            ProvinciaService = new ProvinciaService(contexto);
            BreadcrumpService = new BreadcrumpService();
        }

        public ActionResult Listado()
        {
            if (Session["usuarioId"] == null)
            {
                return Redirect("/Home/Ingresar");
            }
            int id = (int)Session["usuarioId"];
            List<Consorcio> consorcios = ConsorcioService.ObtenerTodosOrdenadosPorNombre(id);
            return View(consorcios);
        }

        public ActionResult Crear()
        {
            ViewBag.ProvinciasItems = ProvinciaService.ObtenerComboProvincias();

            Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
            Breadcrump nivel2 = new Breadcrump("Crear Consorcio");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2);
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Consorcio consorcio, string otraAccion)
        {
            if (Session["usuarioId"] == null)
            {
                return Redirect("/Home/Ingresar");
            }
            consorcio.IdUsuarioCreador = (int)Session["usuarioId"];
            consorcio.FechaCreacion = DateTime.Now;

            if (!ModelState.IsValid)
            {
                TempData["Creado"] = "FALSO";

                ViewBag.ProvinciasItems = ProvinciaService.ObtenerComboProvincias();

                Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
                Breadcrump nivel2 = new Breadcrump("Crear Consorcio");
                ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2);

                return View(consorcio);
            }

            ConsorcioService.Alta(consorcio);
            TempData["Creado"] = consorcio.Nombre.ToString();

            if (otraAccion == "crearUnidades")
            {
                return Redirect("/Unidad/Crear");
            }
            if (otraAccion == "crearOtro")
            {
                return Redirect("Crear");
            }
            return RedirectToAction("Listado");
        }

        public ActionResult Modificar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }

            Consorcio consorcio = ConsorcioService.ObtenerPorId((int)id);
           
            ViewBag.ProvinciasItems = ProvinciaService.ObtenerComboProvincias(consorcio.IdProvincia);

            Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
            Breadcrump nivel2 = new Breadcrump(consorcio.Nombre.ToString(), "Consorcio/Modificar/" + consorcio.IdConsorcio.ToString());
            Breadcrump nivel3 = new Breadcrump("Modificar");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3);
            
            return View(consorcio);
        }

        [HttpPost]
        public ActionResult Modificar(Consorcio consorcio)
        {
            if (!ModelState.IsValid)
            {
                TempData["Modificado"] = "FALSO";

                ViewBag.ProvinciasItems = ProvinciaService.ObtenerComboProvincias(consorcio.IdProvincia);

                Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
                Breadcrump nivel2 = new Breadcrump(consorcio.Nombre.ToString(), "Consorcio/Modificar/" + consorcio.IdConsorcio.ToString());
                Breadcrump nivel3 = new Breadcrump("Modificar");
                ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3);

                return View(consorcio);
            }

            ConsorcioService.Modificar(consorcio);
            TempData["Modificado"] = consorcio.Nombre.ToString();
            return RedirectToAction("Listado");
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }

            Consorcio consorcio = ConsorcioService.ObtenerPorId((int)id);

            Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
            Breadcrump nivel2 = new Breadcrump(consorcio.Nombre.ToString(), "Consorcio/Modificar/" + consorcio.IdConsorcio.ToString());
            Breadcrump nivel3 = new Breadcrump("Eliminar");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3);

            return View(consorcio);
        }

        [HttpPost]
        public ActionResult Eliminar(Consorcio consorcio)
        {
            if (consorcio == null)
            {
                TempData["Eliminado"] = "FALSO";
                return RedirectToAction("Listado");
            }

            TempData["Eliminado"] = consorcio.Nombre.ToString();
            ConsorcioService.Eliminar(consorcio.IdConsorcio);

            return RedirectToAction("Listado");
        }

        public String Existe(string nombre)
        {
            Boolean existe = ConsorcioService.ExisteNombre(nombre);

            if (existe)
            {
                return "Tenga en cuenta que ya existe un consorcio con el mismo nombre";

            }
            return null;
        }
    }
}