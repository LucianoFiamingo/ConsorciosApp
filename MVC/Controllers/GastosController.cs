using Entities.EDMX;
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
        GastosService GastoService;
        TipoGastoService TipoGastoService;
        

        public GastosController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            GastosService gastosService = new GastosService(contexto);
            TipoGastoService tipoGastoService = new TipoGastoService(contexto);
           
        }
        // GET: Gastos
        public ActionResult Listado()
        {
            List<Gasto> gastos = GastoService.ObtenerTodos();
            return View(gastos);
        }

        
        public ActionResult Crear()
        {
            ViewBag.TipoGastoItems = ObtenerComboTipoGasto();
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
                ViewBag.TipoGastoItem = ObtenerComboTipoGasto();
                return RedirectToAction("Crear");
            }

            GastoService.Alta(gasto);
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

            Gasto gasto = GastoService.ObtenerPorId((int)id);
            ViewBag.TipoGastoItem = ObtenerComboTipoGasto(gasto.IdTipoGasto);

            return View(gasto);
        }

        [HttpPost]
        public ActionResult Modificar(Gasto gasto)
        {
            if (!ModelState.IsValid)
            {
                TempData["Modificado"] = false;
                ViewBag.TipoGastoItem = ObtenerComboTipoGasto();
                return View(gasto);
            }

            GastoService.Modificar(gasto);
            TempData["Modificado"] = true;
            return RedirectToAction("Listado");
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }

           Gasto gasto = GastoService.ObtenerPorId((int)id);
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

            GastoService.Eliminar(gasto.IdGasto);
            TempData["Eliminado"] = true;

            return RedirectToAction("Listado");
        }


        public List<SelectListItem> ObtenerComboTipoGasto()
        {
            List<TipoGasto> tipoGastos = TipoGastoService.ObtenerTodos();

            List<SelectListItem> TipoGastoItems = tipoGastos.Select(o => new SelectListItem()
            {
                Text = o.Nombre,
                Value = o.IdTipoGasto.ToString()
            }).ToList();

            TipoGastoItems.Insert(0, new SelectListItem() { Value = "", Text = "Seleccione un tipo de gasto" });

            return TipoGastoItems;
        }

        public List<SelectListItem> ObtenerComboTipoGasto(int id)
        {
            List<TipoGasto> tipoGastos = TipoGastoService.ObtenerTodos();

            List<SelectListItem> TipoGastoItems = tipoGastos.Select(o => new SelectListItem()
            {
                Text = o.Nombre,
                Value = o.IdTipoGasto.ToString(),
                Selected = o.IdTipoGasto == id
            }).ToList();

            TipoGastoItems.Insert(0, new SelectListItem() { Value = "", Text = "Seleccione un tipo de gasto" });

            return TipoGastoItems;
        }
        




    }
}
