using System.Collections.Generic;
using System.Linq;
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

        public ActionResult ViewConsorcio()
        {
            return View();
        }
    }
}