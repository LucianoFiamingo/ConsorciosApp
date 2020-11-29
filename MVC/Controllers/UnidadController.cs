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
            IEnumerable<Unidad> unidCons = UnidadService.ObtenerUnidadesPorIdConsorcio(id, idUsuarioCreador);
            return View(unidCons);
        }


        public ActionResult CrearUnidad()
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {

                return Redirect("/Home/Ingresar");
            }
            return View();
        }


        [HttpPost]
        public ActionResult CrearUnidad(Unidad a)
        {
            if (String.IsNullOrEmpty(Session["usuarioId"].ToString()))
            {

                return Redirect("/Home/Ingresar");
            }

            UnidadService.Alta(a);
            return RedirectToAction("VerUnidades");
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

