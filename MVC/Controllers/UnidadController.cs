using Entities.EDMX;
using Servicios;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UnidadController : Controller
    {
        [HttpGet]
        public ActionResult CrearUnidad()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearUnidad(Unidad a)
        {
            UnidadService.CrearUnidad(a);
            return RedirectToAction("VerUnidades");
        }

        [HttpGet]
        public ActionResult VerUnidades()
        {
            List<Unidad> Lista = UnidadService.ObtenerTodos();
            return View(Lista);
        }

        [HttpGet]
        public ActionResult ModificarUnidad(int id)
        {
            Unidad a = UnidadService.ObtenerPorId(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult ModificarUnidad(Unidad a)
        {
            UnidadService.ModificarUnidad(a);
            return RedirectToAction("VerUnidades");
        }

        public ActionResult EliminarUnidad(int id)
        {
            UnidadService.EliminarUnidad(id);
            return RedirectToAction("VerUnidades");
        }
    }
}