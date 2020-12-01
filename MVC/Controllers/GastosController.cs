using Entities;
using Entities.EDMX;
using Services;
using System;
using System.Collections.Generic;
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
            BreadcrumpService = new BreadcrumpService();
        }
        // GET: Gastos
        public ActionResult Listado(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }
            int idUsuarioCreador = (int)Session["usuarioId"];
            List<Gasto> gastos = gastosService.ObtenerGastosPorConsorcio((int)id , idUsuarioCreador);
            
            Gasto idGasto = gastosService.ObtenerPorId((int)id);
            ViewBag.idConsorcio = id;
            return View(gastos);
        }
       


        public ActionResult Crear(int? id )
        {
            if (id == null)
            {
               return RedirectToAction("Listado");
            }
            Consorcio consorcio = consorcioService.ObtenerPorId((int)id);
            ViewBag.nombreConsorcio = consorcio.Nombre;
            ViewBag.TipoGastoItem = tipoGastoService.ObtenerComboTipoGasto();
            Breadcrump nivel1 = new Breadcrump("Mis gastos", "Gastos/Listado");
            Breadcrump nivel2 = new Breadcrump("Gastos/Crear/" + ViewBag.idConsorcio);
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2);

            return View();
        }


        [HttpPost]
        public ActionResult Crear(Gasto gasto, string otraAccion, HttpPostedFileBase file)
        {
            
            gasto.IdUsuarioCreador = 1;
            gasto.FechaCreacion = DateTime.Now;
            gasto.ArchivoComprobante = file.FileName;

            string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();
            file.SaveAs(Server.MapPath("~/Gastos/" + archivo));

                
            if (!ModelState.IsValid)
            {
                TempData["Creado"] = "FALSO";
                Consorcio consorcio = consorcioService.ObtenerPorId(gasto.IdConsorcio);
                ViewBag.TipoGastoItem = tipoGastoService.ObtenerComboTipoGasto();
                Breadcrump nivel1 = new Breadcrump("Mis gastos", "Gastos/Listado");
                Breadcrump nivel2 = new Breadcrump("Gastos/Crear/" + ViewBag.idConsorcio);
                ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2);

                return View(gasto);
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

            return RedirectToAction("Listado/" + gasto.IdConsorcio);
        }

        public ActionResult Modificar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }

            Gasto gasto = gastosService.ObtenerPorId((int)id);
            ViewBag.TipoGastoItem = tipoGastoService.ObtenerComboTipoGasto(gasto.IdTipoGasto);
            Breadcrump nivel1 = new Breadcrump("Mis gastos", "Gastos/Listado");
            Breadcrump nivel2 = new Breadcrump(gasto.Nombre.ToString(), "Gastos/Modificar/" + gasto.IdGasto.ToString());
            Breadcrump nivel3 = new Breadcrump("Modificar");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3);
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
            Breadcrump nivel1 = new Breadcrump("Mis gastos", "Gastos/Listado");
            Breadcrump nivel2 = new Breadcrump(gasto.Nombre.ToString(), "Gastos/Modificar/" + gasto.IdGasto.ToString());
            Breadcrump nivel3 = new Breadcrump("Modificar");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3);

            return RedirectToAction("Listado/" + gasto.IdConsorcio);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Listado");
            }

           Gasto gasto = gastosService.ObtenerPorId((int)id);
            Breadcrump nivel1 = new Breadcrump("Mis gastos", "Gastos/Listado");
            Breadcrump nivel2 = new Breadcrump(gasto.Nombre.ToString(), "Gastos/Modificar/" + gasto.IdGasto.ToString());
            Breadcrump nivel3 = new Breadcrump("Eliminar");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3);
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
            
            //gastosService.ObtenerPorId(gasto.IdGasto);
            gastosService.Eliminar(gasto.IdGasto);
            TempData["Eliminado"] = true;

            return RedirectToAction("Listado" + "/" + gasto.IdGasto);
        }

        public FileResult DescargarComprobante(int?id)
        {
            Gasto gasto = gastosService.ObtenerPorId((int)id);
            var ruta = Server.MapPath($"~/{gasto.ArchivoComprobante}");
            return File(ruta, "application/pdf", gasto.ArchivoComprobante);
        }

        [HttpPost]
        public ActionResult SubirComprobante(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return RedirectToAction("~/Consorcio/Listado");
            }
                
            string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();

            file.SaveAs(Server.MapPath("~/Gastos/" + archivo));


            return RedirectToAction("SubidaExitosa");
        }

        public ActionResult SubidaExitosa()
        {
            return View();
        }








    }
}
