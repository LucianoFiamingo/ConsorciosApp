using Entities.EDMX;
using Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UnidadController : Controller
    {
        UnidadService UnidadService;

        public UnidadController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            UnidadService = new UnidadService(contexto);
        }
       
        public ActionResult VerUnidades(int id)
        {
            IEnumerable<Unidad> unidCons = UnidadService.ObtenerUnidadesPorIdConsorcio(id);
            return View(unidCons);
        }
        public ActionResult CrearUnidad()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearUnidad(Unidad a)
        {
            UnidadService.Alta(a);
            return RedirectToAction("VerUnidades");
        }
        public ActionResult ModificarUnidad(int id)
        {
            Unidad a = UnidadService.ObtenerPorId(id);
            return View(a);
        }
        [HttpPost]
        public ActionResult ModificarUnidad(Unidad a)
        {
            UnidadService.Modificar(a);
            return RedirectToAction("VerUnidades");
        }
        public ActionResult EliminarUnidad(int id)
        {
            UnidadService.Eliminar(id);
            return RedirectToAction("VerUnidades");
        }
    }
}