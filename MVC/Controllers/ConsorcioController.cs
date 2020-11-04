using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Entities;
using Entities.EDMX;
using Services;

namespace MVC.Controllers
{
    public class ConsorcioController : Controller
    {
        ConsorcioService ConsorcioService;
        ProvinciaService ProvinciaService;
        public ConsorcioController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            ConsorcioService = new ConsorcioService(contexto);
            ProvinciaService = new ProvinciaService(contexto);
        }

        public ActionResult Listado()
        {
            List<Consorcio> consorcios = ConsorcioService.ObtenerTodos();
            return View(consorcios);
        }
        public ActionResult Crear()
        {
            ViewBag.Provincias = ProvinciaService.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Consorcio consorcio, string otraAccion)
        {
            consorcio.IdUsuarioCreador = 1;//usuario logeado
            consorcio.FechaCreacion = DateTime.Now;

            if (!ModelState.IsValid)
            {
                TempData["Creado"] = false;
                return RedirectToAction("Crear");
            }

            ConsorcioService.Alta(consorcio);
            TempData["Creado"] = true;

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
            return View(consorcio);
        }

        [HttpPost]
        public ActionResult Modificar(Consorcio consorcio)
        {
            if (!ModelState.IsValid)
            {
                TempData["Modificado"] = false;
                return View(consorcio);
            }

            ConsorcioService.Modificar(consorcio);
            TempData["Modificado"] = true;

            return RedirectToAction("Listado");
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }

            Consorcio consorcio = ConsorcioService.ObtenerPorId((int)id);

            return View(consorcio);
        }

        [HttpPost]
        public ActionResult Eliminar(Consorcio consorcio)
        {
            if (consorcio == null)
            {
                TempData["Eliminado"] = false;
                return RedirectToAction("Listado");
            }

            ConsorcioService.Eliminar(consorcio.IdConsorcio);
            TempData["Eliminado"] = true;

            return RedirectToAction("Listado");
        }
    }
}