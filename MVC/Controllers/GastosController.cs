using Entities;
using Entities.EDMX;
using Services;
using Services.Gastos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class GastosController : Controller
    {
        ConsorcioService consorcioService;
        GastosService gastosService;
        TipoGastoService tipoGastoService;
        BreadcrumpService BreadcrumpService;

        public GastosController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            this.gastosService = new GastosService(contexto);
            this.tipoGastoService = new TipoGastoService(contexto);
            this.consorcioService = new ConsorcioService(contexto);
           
        }
        // GET: Gastos
        public ActionResult Listado(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }

            List<Gasto> gastos = gastosService.ObtenerGastosPorConsorcio((int)id);
            return View(gastos);
        }

        
        public ActionResult Crear(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }

            Gasto gasto = gastosService.ObtenerPorId((int)id);
            ViewBag.TipoGastoItem = tipoGastoService.ObtenerComboTipoGasto(gasto.IdTipoGasto);

            return View();
        }


        [HttpPost]
        public ActionResult Crear(Gasto gasto, string otraAccion)
        {

            gasto.IdUsuarioCreador = 1;
            gasto.FechaCreacion = DateTime.Now;

            if (!ModelState.IsValid)
            {
                TempData["Creado"] = false;
                //ViewBag.TipoGastoItem = TipoGastoService.ObtenerComboTipoGasto();
                return RedirectToAction("Crear");
            }

            gastosService.Alta(gasto);
            TempData["Creado"] = true;

            if (otraAccion == "crearGasto")
            {
                return Redirect("/Gasto/Crear");
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

            Gasto gasto = gastosService.ObtenerPorId((int)id);
            ViewBag.TipoGastoItem = tipoGastoService.ObtenerComboTipoGasto(gasto.IdTipoGasto);

            return View(gasto);
        }

        [HttpPost]
        public ActionResult Modificar(Gasto gasto)
        {
            if (!ModelState.IsValid)
            {
                TempData["Modificado"] = false;
                ViewBag.TipoGastoItem = tipoGastoService.ObtenerComboTipoGasto();
                return View(gasto);
            }

            gastosService.Modificar(gasto);
            TempData["Modificado"] = true;
            return RedirectToAction("Listado");
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }

           Gasto gasto = gastosService.ObtenerPorId((int)id);
            return View(gasto);
        }

        [HttpPost]
        public ActionResult Eliminar(Gasto gasto)
        {
            if (gasto == null)
            {
                TempData["Eliminado"] = false;
                return RedirectToAction("Listado");
            }
            var idConsorcio = consorcioService.ObtenerPorId(gasto.Consorcio.IdConsorcio);
            gastosService.Eliminar(gasto.IdGasto);
            TempData["Eliminado"] = true;

            return RedirectToAction("Listado" + "/" + idConsorcio);
        }


        
        




    }
}
