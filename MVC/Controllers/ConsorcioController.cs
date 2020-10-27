using System.Collections.Generic;
using System.Web.Mvc;
using Entities.EDMX;
using Servicios;

namespace MVC.Controllers
{
    public class ConsorcioController : Controller
    {
        ConsorcioService consorcioService;
        public ConsorcioController()
        {
            this.consorcioService = new ConsorcioService();
        }

        public ActionResult Listado()
        {
            List<Consorcio> consorcios = consorcioService.GetAll();
            return View(consorcios);
        }  
        public ActionResult Crear()
        {
            
            Provincia provincia1 = new Provincia() { Nombre = "CABA", IdProvincia = 1 };
            Provincia provincia2 = new Provincia() { Nombre = "Santa Fe", IdProvincia = 2};

            List<Provincia> provincias = new List<Provincia>() {provincia1, provincia2};

            return View();
        } 

        [HttpPost]
        public ActionResult Crear(Consorcio consorcio, string otraAccion)
        {
            //Service.Add(consorcio);
            if (!ModelState.IsValid) {
                return RedirectToAction("Listado");
              }

            if (otraAccion == "crearUnidades")
            {
                TempData["Creado"] = true;
                return Redirect("Unidad/Crear");
            }  
            
            if (otraAccion == "crearOtro")
            {
                TempData["Creado"] = true;
                return Redirect("Crear");
            }

            return RedirectToAction("Listado");
        }

    }
}