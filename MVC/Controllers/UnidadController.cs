using Entities.EDMX;
using Servicios;
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
            var Lista = UnidadService.ObtenerTodos();
            return View(Lista);
        }
    }
}