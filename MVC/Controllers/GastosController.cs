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
                return Redirect("/Consorcio/Listado");
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
                return Redirect("/Consorcio/Listado");
            }
            Consorcio consorcio = consorcioService.ObtenerPorId((int)id);
            ViewBag.nombreConsorcio = consorcio.Nombre;
            ViewBag.idConsorcio = consorcio.IdConsorcio;
            ViewBag.TipoGastoItem = tipoGastoService.ObtenerComboTipoGasto();
            Breadcrump nivel1 = new Breadcrump("Mis Consorcios", "Consorcio/Listado");
            Breadcrump nivel2 = new Breadcrump("Consorcio " + consorcio.Nombre.ToString(), "Consorcio/Modificar/" + id);
            Breadcrump nivel3 = new Breadcrump("Gastos", "Gastos/Listado/" + id);
            Breadcrump nivel4 = new Breadcrump("Cargar Nuevo Gasto");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3, nivel4);

            return View();
        }


        [HttpPost]
        public ActionResult Crear(Gasto gasto, string otraAccion, HttpPostedFileBase ArchivoComprobante)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                return Redirect("/Home/Ingresar");
            }
            int idUsuarioCreador = (int)Session["usuarioId"];
            gasto.IdUsuarioCreador = idUsuarioCreador;
            gasto.FechaCreacion = DateTime.Now;
            string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + ArchivoComprobante.FileName).ToLower();
            gasto.ArchivoComprobante = archivo;
            ArchivoComprobante.SaveAs(Server.MapPath("~/" + archivo));

            if (!ModelState.IsValid)
            {
                TempData["Creado"] = "FALSO";
                Consorcio consorcio = consorcioService.ObtenerPorId(gasto.IdConsorcio);
                ViewBag.idConsorcio = consorcio.IdConsorcio;
                ViewBag.nombreConsorcio = consorcio.Nombre;
                ViewBag.TipoGastoItem = tipoGastoService.ObtenerComboTipoGasto();
                Breadcrump nivel1 = new Breadcrump("Mis gastos", "Gastos/Listado");
                Breadcrump nivel2 = new Breadcrump("Gastos/Crear/" + ViewBag.idConsorcio);
                ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2);

                return View(gasto);
            }

            gastosService.Alta(gasto);

            TempData["Creado"] = gasto.Nombre.ToString();

            if (otraAccion == "crearGasto")
            {
                return Redirect("/Gasto/Crear" + gasto.IdConsorcio);
            }
            if (otraAccion == "crearOtro")
            {
                return Redirect("Crear/" + gasto.IdConsorcio);
            }

            return RedirectToAction("Listado/" + gasto.IdConsorcio);
        }

        public ActionResult Modificar(int? id)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                TempData["Redirect"] = "/Gastos/Modificar/" + id.ToString();
                return Redirect("/Home/Ingresar");
            }

            if (id == null)
            {
                return Redirect("/Consorcio/Listado");
            }

            Gasto gasto = gastosService.ObtenerPorId((int)id); 
            int idUs = (int)gasto.IdUsuarioCreador;
            
            if (idUs != (int)Session["usuarioId"])
            {
                return RedirectToAction("Listado/" + gasto.IdGasto);
            }

            ViewBag.TipoGastoItem = tipoGastoService.ObtenerComboTipoGasto(gasto.IdTipoGasto);
            Consorcio consorcio = consorcioService.ObtenerPorId(gasto.IdConsorcio);
            ViewBag.idConsorcio = consorcio.IdConsorcio;
            ViewBag.nombreConsorcio = consorcio.Nombre;
            ViewBag.ArchivoComprobante = gasto.ArchivoComprobante;

            Breadcrump nivel1 = new Breadcrump("Mis gastos", "Gastos/Listado");
            Breadcrump nivel2 = new Breadcrump(gasto.Nombre.ToString(), "Gastos/Modificar/" + gasto.IdGasto.ToString());
            Breadcrump nivel3 = new Breadcrump("Modificar");
            ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3);
            return View(gasto);
        }

        [HttpPost]
        public ActionResult Modificar(Gasto gasto)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                return Redirect("/Home/Ingresar");
            }

            if (!ModelState.IsValid)
            {
                TempData["Modificado"] = "FALSO";
                ViewBag.TipoGastoItem = tipoGastoService.ObtenerComboTipoGasto();
                Consorcio consorcio = consorcioService.ObtenerPorId(gasto.IdConsorcio);
                ViewBag.idConsorcio = consorcio.IdConsorcio;
                ViewBag.nombreConsorcio = consorcio.Nombre;
                
                Breadcrump nivel1 = new Breadcrump("Mis gastos", "Gastos/Listado");
                Breadcrump nivel2 = new Breadcrump(gasto.Nombre.ToString(), "Gastos/Modificar/" + gasto.IdGasto.ToString());
                Breadcrump nivel3 = new Breadcrump("Modificar");
                ViewBag.Breadcrumps = BreadcrumpService.SetListaBreadcrumps(nivel1, nivel2, nivel3);

                return View(gasto);
            }
            gastosService.Modificar(gasto);
            TempData["Modificado"] = gasto.Nombre.ToString();
            return RedirectToAction("Listado/" + gasto.IdConsorcio);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return Redirect("/Consorcio/Listado");
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
                return Redirect("/Consorcio/Listado");
            }
            gastosService.ObtenerPorId(gasto.IdGasto);
            Consorcio consorcio = consorcioService.ObtenerPorId(gasto.IdConsorcio);
            var idConsorcio = consorcio.IdConsorcio;
            gastosService.Eliminar(gasto.IdGasto);
            TempData["Eliminado"] = true;

            return RedirectToAction("Listado" + "/" + idConsorcio);
        }

        public FileResult DescargarComprobante(int?id)
        {
            Gasto gasto = gastosService.ObtenerPorId((int)id);
            var ruta = Server.MapPath($"~/{gasto.ArchivoComprobante}");
            return File(ruta, "application/pdf", gasto.ArchivoComprobante);
        }

        

        








    }
}
