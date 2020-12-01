using Entities.EDMX;
using Services;
using System;
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
            int idUsuarioCreador = (int)Session["usuarioId"];
          
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {
                TempData["Redirect"] = "/Unidad/VerUnidades";
                return Redirect("/Home/Ingresar");
            }
            List<Unidad> unidCons = UnidadService.ObtenerUnidadesPorConsorcioYOrdenadosPorNombre(id, idUsuarioCreador);

            ViewBag.IdConsorcio = id;

            return View(unidCons);
        }

        public ActionResult CrearUnidad(int id)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {

                return Redirect("/Home/Ingresar");
            }

            Consorcio c = UnidadService.ObtenerPorIdConsorcio(id);

            ViewBag.Nombre = c.Nombre;
            ViewBag.IdConsorcio = c.IdConsorcio;

            return View();

        }

        [HttpPost]
        public ActionResult CrearUnidad(Unidad a)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {

                return Redirect("/Home/Ingresar");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

           a.IdUsuarioCreador = (int)Session["usuarioId"];
           a.FechaCreacion = DateTime.Now;
           UnidadService.Alta(a);
           return RedirectToAction("VerUnidades", new { Id = a.IdConsorcio });
        }

        public ActionResult ModificarUnidad(int id)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {

                return Redirect("/Home/Ingresar");
            }

            Unidad a = UnidadService.ObtenerPorId(id);

            int idUs = (int)a.Consorcio.IdUsuarioCreador;

            if (idUs != (int)Session["usuarioId"])
            {
                return RedirectToAction("Listado");
            }

            return View(a);
        }


        [HttpPost]
        public ActionResult ModificarUnidad(Unidad a)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {

                return Redirect("/Home/Ingresar");
            }

            UnidadService.Modificar(a);
            return RedirectToAction("VerUnidades");
        }


        public ActionResult EliminarUnidad(int id)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {

                return Redirect("/Home/Ingresar");
            }

            Unidad a = UnidadService.ObtenerPorId(id);

            int idUs = (int)a.Consorcio.IdUsuarioCreador;

            if (idUs != (int)Session["usuarioId"])
            {
                return RedirectToAction("Listado");
            }


            UnidadService.Eliminar(a.IdUnidad);
            return RedirectToAction("VerUnidades");
        }
    }
}

