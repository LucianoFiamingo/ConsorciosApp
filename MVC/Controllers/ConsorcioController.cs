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
        ConsorcioService consorcioService;
        public ConsorcioController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            consorcioService = new ConsorcioService(contexto);
        }

        public ActionResult Listado()
        {
            List<Consorcio> consorcios = consorcioService.ObtenerTodos();
            return View(consorcios);
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Consorcio consorcio, string otraAccion)
        {

            if (!ModelState.IsValid)
            {
                TempData["Creado"] = false;
                return RedirectToAction("Crear");
            }

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

        public ActionResult Modificar(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }

            Consorcio consorcio = consorcioService.ObtenerPorId((long)id);
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

            consorcioService.Modificar(consorcio);
            TempData["Modificado"] = true;

            return RedirectToAction("Listado");
        }

        public ActionResult Eliminar(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }

            Consorcio consorcio = consorcioService.ObtenerPorId((long)id);

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

            consorcioService.Eliminar(consorcio.IdConsorcio);
            TempData["Eliminado"] = true;

            return RedirectToAction("Listado");
        }
    }
}